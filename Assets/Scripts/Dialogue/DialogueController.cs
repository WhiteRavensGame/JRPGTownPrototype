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

    private bool waitingForAnswer = true;

    private void Awake()
    {
        story = new Story[inkJson.Length];
        story[0] = new Story(inkJson[0].text);
        story[1] = new Story(inkJson[1].text);
    }

    private void OnMouseDown()
    {
        dialogObjects[0].SetActive(true);

        if(story[0].canContinue)
        {
            dialogueText.text = story[0].Continue();
        }
        else if (story[1].canContinue)
        {
            dialogueText.text = story[1].Continue();

            for(int i = 0; i < story[1].currentChoices.Count; ++i) 
            {
                buttonsText[i].text = story[1].currentChoices[i].text;
                dialogObjects[i + 1].SetActive(true);
            }
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
        dialogueText.text = story[1].Continue();

        for (int i = 1; i < dialogObjects.Length; ++i)
        {
            dialogObjects[i].SetActive(false);
        }
    }
}
