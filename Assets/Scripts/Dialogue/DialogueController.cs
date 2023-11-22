using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] dialogObjects;
    private List<GameObject> buttonObjects;
    private List<int> functionIndex;

    [SerializeField] private TextAsset[] inkJson;
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
        buttonObjects = new List<GameObject>();
        functionIndex = new List<int>();

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
        if (loadingText && currentWord <= currentStory.Length)
        {
            dialogueText.text = currentStory;
            currentWord = currentStory.Length;
            return;
        }

        dialogObjects[0].SetActive(true);

        if (story[0].canContinue)
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

        for (int i = 0; i < buttonObjects.Count; ++i)
        {
            Destroy(buttonObjects[i]);
        }
        buttonObjects.Clear();
        functionIndex.Clear();
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
            }
        }
        else if (story[1].currentChoices.Count > 0 && buttonObjects.Count == 0)
        {
            for (int i = 0; i < story[1].currentChoices.Count; ++i)
            {
                int index = i;
                functionIndex.Add(index);
                buttonObjects.Add(Instantiate(dialogObjects[1], Vector3.zero, Quaternion.identity, transform.GetChild(0)));
                buttonObjects[i].transform.localPosition = new Vector3(-100, 0 + (i * 50), 0);
                buttonObjects[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = story[1].currentChoices[i].text;
                buttonObjects[i].gameObject.GetComponent<Button>().onClick.AddListener(delegate { ChooseDialogue(functionIndex[index]); });
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
