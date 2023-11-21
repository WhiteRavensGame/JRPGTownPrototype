using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] KeyValuePair<Resources, int> resources;
    [SerializeField] List<int> resourcesAmount;
    [SerializeField] private TextAsset inkJson;
    private Story story;

    [SerializeField] private float wordSpeed;
    private float textAnimTimer;
    private bool loadingText = false;
    private int currentWord = 0;

    private bool waitingForAnswer = false;
}
