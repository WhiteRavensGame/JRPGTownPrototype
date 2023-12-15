using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DecisionSceneScript : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionReference _action;
    private InputAction _leftClick;

    [Space, Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private List<GameObject> buttons;

    [Space, Header("Story")]
    [SerializeField] private Ending storyEnding;
    private Story _currentStory;

    [Space, Header("Variables")]
    [SerializeField] private float wordSpeed;
    private string currentText;
    private float textAnimTimer;
    private int currentWord;

    private bool loadingText = false;
    public string choice;

    [SerializeField] private TextAsset jsonAsset;

    public void OnEnable()
    {
        _currentStory = new Story(jsonAsset.text);

        switch (choice)
        {
            case "Oscar Herring":
                _currentStory.variablesState["Oscar"] = true;
                break;
            case "Lorraine Florrace":
                _currentStory.variablesState["Lorraine"] = true;
                break;
            case "Will Van Merrin":
                _currentStory.variablesState["Will"] = true;
                break;
            case "Adelaine Sharp":
                _currentStory.variablesState["Adelaine"] = true;
                break;
            case "Roe Kimp":
                _currentStory.variablesState["Roe"] = true;
                break;
            default: break;
        }

        LoadTextAnim();
        CheckAnswers();

        _leftClick = _action.action;
        _leftClick.Enable();
        _leftClick.performed += OnClick;

    }

    private void Update()
    {
        if (loadingText)
        {
            textAnimTimer -= Time.deltaTime;

            if (textAnimTimer <= 0.0f && currentWord < currentText.Length)
            {
                dialogueText.text += currentText[currentWord++];
                textAnimTimer = wordSpeed;
            }
            else if (currentWord >= currentText.Length)
            {
                loadingText = false;
                CheckAnswers();
            }
        }
    }

    private void OnClick(InputAction.CallbackContext input)
    {
        if (_currentStory.canContinue || _currentStory.currentChoices.Count > 0)
        {
            LoadTextAnim();
        }
    }

    public void LoadTextAnim()
    {
        if (!loadingText && _currentStory.canContinue)
        {
            dialogueText.text = "";
            loadingText = true;
            currentWord = 0;
            textAnimTimer = wordSpeed;
            currentText = _currentStory.Continue();
        }
        else
        {
            loadingText = false;
            dialogueText.text = currentText;
            CheckAnswers();
        }
    }

    private void CheckAnswers()
    {
        if(_currentStory.currentChoices.Count == 0 && buttons[0].active)
        {
            for (int i = 0; buttons.Count > i; ++i)
            {
                buttons[i].SetActive(false);
            }
        }

        for (int i = 0; _currentStory.currentChoices.Count > i; ++i)
        {
            buttons[i].SetActive(true);
            var text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            text.text = _currentStory.currentChoices[i].text;
        }
    }

    public void ChooseOption(int index)
    {
        if (_currentStory.currentChoices.Count > 0)
        {
            ServiceLocator.Get<SoundManager>().Play("Choose");

            _leftClick.Disable();
            _leftClick.performed -= OnClick;
            _currentStory.ChooseChoiceIndex(index);
            storyEnding.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

