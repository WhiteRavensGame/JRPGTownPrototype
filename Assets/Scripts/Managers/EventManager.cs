using UnityEngine;
using UnityEngine.Events;
using Ink.Runtime;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent endOfDay;

    private MainDialogue dialogue;
    [SerializeField] private List<TextAsset> _weekOneTexts = new();
    [SerializeField] private List<TextAsset> _weekTwoTexts = new();
    [SerializeField] private List<TextAsset> _weekThreeTexts = new();
    [SerializeField] private List<TextAsset> _weekFourTexts = new();

    public void Initialize()
    {
        dialogue = ServiceLocator.Get<MainDialogue>();
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
        if(weeksList.Count <= 0)
        {
            return;
        }

        var randNum = Random.Range(0, weeksList.Count);
        dialogue.Enter(weeksList[randNum]);
    }
}
