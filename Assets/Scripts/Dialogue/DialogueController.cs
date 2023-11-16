using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject panel;

    [SerializeField] private TextAsset inkJson;
    private Story story;
    private string currentStory;

    [SerializeField] private float wordSpeed;
    private float textAnimTimer;
    private bool loadingText = false;
    private int currentWord = 0;

    private bool waitingForAnswer = false;

    [SerializeField] private GameObject[] buttons;

    private void Awake()
    {
        story = new Story(inkJson.text);

        textAnimTimer = wordSpeed;
    }

    private void Update()
    {
        LoadTextWithAnim();
    }

    private void OnMouseDown()
    {
        panel.SetActive(true);

        if (loadingText && currentWord <= currentStory.Length)
        {
            dialogueText.text = currentStory;
            currentWord = currentStory.Length;
            return;
        }

        if (story.canContinue && !waitingForAnswer)
        {
            ContinueStory();
        }
        else if(!story.canContinue)
        {
            panel.SetActive(false);
        }
    }

    public void ChooseDialogue(int index)
    {
        LoadChoices(false);
        waitingForAnswer = false;
        story.ChooseChoiceIndex(index);
        ContinueStory();
    }

    private void LoadTextWithAnim()
    {
        if (loadingText)
        {
            textAnimTimer -= Time.deltaTime;

            if (textAnimTimer <= 0 && currentWord < currentStory.Length)
            {
                dialogueText.text += currentStory[currentWord++];
                textAnimTimer = wordSpeed;
            }
            else if (currentWord >= currentStory.Length)
            {
                loadingText = false;
                LoadChoices(true);
            }
        }
    }

    private void ContinueStory()
    {
        dialogueText.text = "";
        currentStory = story.Continue();
        loadingText = true;
        currentWord = 0;
    }

    private void LoadChoices(bool active)
    {
        waitingForAnswer = active;

        for (int i = 0; story.currentChoices.Count > i; ++i)
        {
            buttons[i].SetActive(active);
        }
    }

}
