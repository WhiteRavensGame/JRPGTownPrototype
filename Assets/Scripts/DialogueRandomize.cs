using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueRandomize : MonoBehaviour
{
    [SerializeField, TextArea(2,10)]
    private List<string> dialogue = new();

    [SerializeField]
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        text.text = dialogue[Random.Range(0, dialogue.Count)];
    }
}
