using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI[] buttonsText;
    [SerializeField]
    private GameObject[] dialogObjects;

    [SerializeField]
    private TextAsset[] inkJson;
    private Story[] story;
    private string currentStory;

    [SerializeField]
    private float wordSpeed;
    private float textAnimTimer;
    private bool loadingText = false;
    private int currentWord = 0;

    private bool waitingForAnswer = true;

    private void Awake()
    {
        story = new Story[inkJson.Length];
        story[0] = new Story(inkJson[0].text);
        story[1] = new Story(inkJson[1].text);

        textAnimTimer = wordSpeed;
    }

    private void Update()
    {
        LoadTextWithAnim();
    }

    private void OnMouseDown()
    {
        if(loadingText && currentWord <= currentStory.Length)
        {
            dialogueText.text = currentStory;
            Debug.Log("stop");
            return;
        }

        dialogObjects[0].SetActive(true);

        if(story[0].canContinue)
        {
            ContinueStory(0);
        }
        else if (story[1].canContinue)
        {
            ContinueStory(1);
        }
        else if (!waitingForAnswer)
        {
            dialogObjects[0].SetActive(false);
            story[0] = new Story(inkJson[0].text);
            story[1] = new Story(inkJson[1].text);
        }
    }

    public void ChooseDialogue(int index)
    {
        waitingForAnswer = false;
        story[1].ChooseChoiceIndex(index);
        ContinueStory(1);

        for (int i = 1; i < dialogObjects.Length; ++i)
        {
            dialogObjects[i].SetActive(false);
        }
    }

    private void LoadTextWithAnim()
    {
        if (loadingText)
        {
            textAnimTimer -= Time.deltaTime;

            if(textAnimTimer <= 0 && currentWord < currentStory.Length)
            {
                dialogueText.text += currentStory[currentWord++];
                textAnimTimer = wordSpeed;
            }
            else if(currentWord >= currentStory.Length)
            {
                loadingText = false;
            }
        }
        else
        {
            for (int i = 0; i < story[1].currentChoices.Count; ++i)
            {
                buttonsText[i].text = story[1].currentChoices[i].text;
                dialogObjects[i + 1].SetActive(true);
            }
        }
    }

    private void ContinueStory(int index)
    {
        dialogueText.text = "";
        currentStory = story[index].Continue();
        loadingText = true;
        currentWord = 0;
    }

}
