using UnityEngine;
using UnityEngine.Events;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent endOfDay;
    [SerializeField] public GameObject _button;

    private MainDialogue dialogue;
    [SerializeField] private List<TextAsset> _weekOneTexts = new();
    [SerializeField] private List<TextAsset> _weekTwoTexts = new();
    [SerializeField] private List<TextAsset> _weekThreeTexts = new();
    [SerializeField] private List<TextAsset> _weekFourTexts = new();

    public void Initialize()
    {
        dialogue = ServiceLocator.Get<MainDialogue>();

    }

    public void CheckEvent()
    {
        int week = ServiceLocator.Get<TimeManager>().GetWeek();
        WeeklyEvent(week);
    }

    public void WeeklyEvent(int weekNum)
    {
        switch (weekNum)
        {
            case 1:
                RandomizeEventList(_weekOneTexts);
                break;
            case 2:
                RandomizeEventList(_weekTwoTexts);
                break;
            case 3:
                RandomizeEventList(_weekThreeTexts);
                break;
            case 4:
                RandomizeEventList(_weekFourTexts);
                break;
            default:
                break;
        }
    }

    private void RandomizeEventList(List<TextAsset> weeksList)
    {
        if (weeksList.Count <= 0)
        {
            return;
        }

        _button.SetActive(true);
    }

    public void ButtonPressed()
    {
        _button.SetActive(false);
        int week = ServiceLocator.Get<TimeManager>().GetWeek();

        var randNum = 0;

        switch (week)
        {
            case 1:
                randNum = Random.Range(0, _weekOneTexts.Count);
                dialogue.Enter(_weekOneTexts[randNum]);
                break;
            case 2:
                randNum = Random.Range(0, _weekTwoTexts.Count);
                dialogue.Enter(_weekTwoTexts[randNum]);
                break;
            case 3:
                randNum = Random.Range(0, _weekThreeTexts.Count);
                dialogue.Enter(_weekThreeTexts[randNum]);
                break;
            case 4:
                randNum = Random.Range(0, _weekFourTexts.Count);
                dialogue.Enter(_weekFourTexts[randNum]);
                break;
            default:
                break;
        }

        ServiceLocator.Get<PlayerManager>().gameState = GameStates.Talking;
    }

    public void SetUpButton(Button button)
    {
        button.onClick.AddListener(ButtonPressed);
        button.gameObject.SetActive(false);
        _button = button.gameObject;
    }
}
