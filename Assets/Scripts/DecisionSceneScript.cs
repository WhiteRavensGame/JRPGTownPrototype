using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Mono.Cecil;

public class DecisionSceneScript : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionReference _action;
    private InputAction _leftClick;

    [Space, Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private List<GameObject> buttons;

    [Space, Header("Story")]
    private Story _currentStory;

    [Space, Header("Variables")]
    [SerializeField] private float wordSpeed;
    private string currentText;
    private float textAnimTimer;
    private int currentWord;

    private bool loadingText = false;
    static string choice;

    [SerializeField] private TextAsset jsonAsset;

    public void Awake()
    {
        _currentStory = new Story(jsonAsset.text);

        LoadTextAnim();

        switch (choice) { case "characterChoice": break; }
    }

    private void Exit()
    {
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
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
                CheckAnswers(true);
            }
        }
    }

    private void OnClick(InputAction.CallbackContext input)
    {
        if (_currentStory.canContinue || _currentStory.currentChoices.Count > 0)
        {
            LoadTextAnim();
        }
        else if (!_currentStory.canContinue && _currentStory.currentChoices.Count <= 0)
        {
            Exit();
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
            CheckAnswers(true);
        }

        if (currentText == "")
        {
            Exit();
        }
    }

    private void CheckAnswers(bool active)
    {
        if (_currentStory.currentChoices.Count > 0)
        {
            for (int i = 0; _currentStory.currentChoices.Count > i; ++i)
            {
                var text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                text.text = _currentStory.currentChoices[i].text;

            }
        }
    }

    public void ChooseOption(int index)
    {
        if (_currentStory.currentChoices.Count > 0)
        {
            
            _currentStory.ChooseChoiceIndex(index);

            if (!_currentStory.canContinue)
            {
                Exit();
            }
            else
            {
                LoadTextAnim();
            }
        }

    }


    private void OnDisable()
    {
        _leftClick.Disable();
        _leftClick.performed -= OnClick;

    }
}

