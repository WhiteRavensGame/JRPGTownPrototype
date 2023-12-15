using UnityEngine;
using UnityEngine.Events;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] public GameObject _button;

    private PlayerManager _playerManager;
    private MainDialogue dialogue;
    [SerializeField] private List<TextAsset> _weekOneTexts = new();
    [SerializeField] private List<TextAsset> _weekTwoTexts = new();
    [SerializeField] private List<TextAsset> _weekThreeTexts = new();
    [SerializeField] private List<TextAsset> _weekFourTexts = new();

    public void Initialize()
    {
        dialogue = ServiceLocator.Get<MainDialogue>();
        _playerManager = ServiceLocator.Get<PlayerManager>();
    }

    public void CheckEvent()
    {
        int week = ServiceLocator.Get<TimeManager>().GetWeek();
        if (Random.Range(0, 100) % 2 == 0)
        {
            ServiceLocator.Get<SoundManager>().Play("New_Event");
            ServiceLocator.Get<TimeManager>().HasEvent(true);
            WeeklyEvent(week);
        }
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
        if (_playerManager.gameState != GameStates.MainScreen)
        {
            return;
        }

        _playerManager.gameState = GameStates.Talking;

        _button.SetActive(false);
        int week = ServiceLocator.Get<TimeManager>().GetWeek();

        var randNum = 0;
        dialogue.gameObject.SetActive(true);

        switch (week)
        {
            case 1:
                randNum = Random.Range(0, _weekOneTexts.Count);
                dialogue.Enter(_weekOneTexts[randNum]);
                _weekOneTexts.RemoveAt(randNum);
                break;
            case 2:
                randNum = Random.Range(0, _weekTwoTexts.Count);
                dialogue.Enter(_weekTwoTexts[randNum]);
                _weekTwoTexts.RemoveAt(randNum);
                break;
            case 3:
                randNum = Random.Range(0, _weekThreeTexts.Count);
                dialogue.Enter(_weekThreeTexts[randNum]);
                _weekThreeTexts.RemoveAt(randNum);
                break;
            case 4:
                randNum = Random.Range(0, _weekFourTexts.Count);
                dialogue.Enter(_weekFourTexts[randNum]);
                _weekFourTexts.RemoveAt(randNum);
                break;
            default:
                break;
        }
    }

    public void SetUpButton(Button button)
    {
        button.onClick.AddListener(ButtonPressed);
        button.gameObject.SetActive(false);
        _button = button.gameObject;
    }
}
