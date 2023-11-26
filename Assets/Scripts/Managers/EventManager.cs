using UnityEngine;
using UnityEngine.Events;
using Ink.Runtime;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent endOfDay;

    [SerializeField] private List<TextAsset> _weekOneTexts = new();
    [SerializeField] private List<TextAsset> _weekTwoTexts = new();
    [SerializeField] private List<TextAsset> _weekThreeTexts = new();
    [SerializeField] private List<TextAsset> _weekFourTexts = new();

}
