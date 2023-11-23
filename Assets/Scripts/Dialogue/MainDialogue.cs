using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class MainDialogue : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionReference _action;
    private InputAction _leftClick;

    [Space, Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject _UIpanel;
    [SerializeField] private List<GameObject> buttons;

    [Space, Header("Story")]
    [SerializeField] private TextAsset _inkJson;
    private Story _currentStory;

    [Space, Header("Variables")]
    [SerializeField] private float wordSpeed;
    private string currentText;
    private float textAnimTimer;
    private int currentWord;

    private bool _isWaitingForAnswer = false;
    private bool loadingText = false;

    public void Enter()
    {
        _UIpanel.SetActive(true);
    }

    private void Exit()
    {
        _UIpanel.SetActive(false);
    }

    private void Awake()
    {
        _currentStory = new Story(_inkJson.text);
        CheckVariable();

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
        if (_currentStory.canContinue && !_isWaitingForAnswer)
        {
            LoadTextAnim();
        }
        else if (!_currentStory.canContinue && !_isWaitingForAnswer)
        {
            Exit();
        }
    }
    public void LoadTextAnim()
    {
        if (!loadingText)
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
    }

    private void CheckAnswers(bool active)
    {
        if (_currentStory.currentChoices.Count > 0)
        {
            _isWaitingForAnswer = active;
            for (int i = 0; _currentStory.currentChoices.Count > i; ++i)
            {
                buttons[i].SetActive(active);
            }
        }
    }

    public void ChooseOption(int index)
    {
        CheckAnswers(false);
        _currentStory.ChooseChoiceIndex(index);
        _currentStory.Continue();
    }

    private void CheckVariable()
    {
        //_currentStory.BindExternalFunction("AddValue", (int val) => {

        //});
    }
    private void OnDestroy()
    {
        _leftClick.Disable();
        _leftClick.performed -= OnClick;
        //_currentStory.UnbindExternalFunction("AddValue");
    }
}
