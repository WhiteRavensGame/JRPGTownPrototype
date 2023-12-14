using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Ink.Runtime;

public class Ending : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionReference _action;
    private InputAction _leftClick;

    [Space, Header("UI")]
    public GameObject playerButton;

    public List<GameObject> popUps;
    public GameObject button;
    public int index = 0;
    public int textIndex = 0;

    [Space, Header("Texts Story")]
    [SerializeField] private List<TextMeshProUGUI> panelsTexts;
    [SerializeField] private List<TextAsset> stories;
    private Story _currentStory;

    [Space, Header("Variables")]
    [SerializeField] private float wordSpeed;
    private string currentText;
    private float textAnimTimer;
    private int currentWord;

    private bool loadingText = false;

    private void Awake()
    {
        _currentStory = new Story(stories[index].text);
        //_currentStory.variablesState["troops"] = ServiceLocator.Get<GameManager>().WVariables.Troops;
        //_currentStory.variablesState["morale"] = ServiceLocator.Get<GameManager>().WVariables.Moral;
        //_currentStory.variablesState["gold"] = ServiceLocator.Get<GameManager>().WVariables.Gold;
        //_currentStory.variablesState["food"] = ServiceLocator.Get<GameManager>().WVariables.Food;
        //_currentStory.variablesState["material"] = ServiceLocator.Get<GameManager>().WVariables.Material;
        //_currentStory.variablesState["silk"] = ServiceLocator.Get<GameManager>().WVariables.Silk;
        LoadTextAnim();
    }

    private void OnEnable()
    {
        _leftClick = _action.action;
        _leftClick.Enable();
        _leftClick.performed += OnClick;
    }

    public void Go2CharacterEndings()
    {
        if (index >= popUps.Count - 1)
        {
            SceneManager.LoadScene("Ending");
            return;
        }
        button.SetActive(true);
        popUps[index++].SetActive(false);
        popUps[index].SetActive(true);
        //ServiceLocator.Get<GameManager>().SaveEnding((string)_currentStory.variablesState["endingName"]);
        _currentStory = new Story(stories[index].text);
        //_currentStory.variablesState["Morale"] = ServiceLocator.Get<GameManager>().WVariables.Moral;
        loadingText = false;
        LoadTextAnim();
    }

    public void NextCharacter()
    {
        if (index >= popUps.Count - 1)
        {
            SceneManager.LoadScene("Ending");
            return;
        }
        else if(loadingText)
        {
            currentText = _currentStory.currentText;
            _currentStory.Continue();
        }

        playerButton.SetActive(false);
        popUps[index++].SetActive(false);
        popUps[index].SetActive(true);
        button.gameObject.SetActive(true);
        currentText = "-";
        loadingText = false;
        LoadTextAnim();
    }

    public void LoadTextAnim()
    {
        if (currentText == "y\n")
        {
            return;
        }

        if (!loadingText && _currentStory.canContinue)
        {
            currentText = _currentStory.Continue();
            if (currentText != "y\n")
            {
                panelsTexts[index].text = "";
                loadingText = true;
                currentWord = 0;
                textAnimTimer = wordSpeed;
            }
        }
        else if (currentText != "y\n")
        {
            loadingText = false;
            panelsTexts[index].text = currentText;
        }
    }

    private void Update()
    {
        if (loadingText)
        {
            textAnimTimer -= Time.deltaTime;

            if (textAnimTimer <= 0.0f && currentWord < currentText.Length)
            {
                panelsTexts[index].text += currentText[currentWord++];
                textAnimTimer = wordSpeed;
            }
            else if (currentWord >= currentText.Length)
            {
                loadingText = false;
            }
        }
    }

    private void OnClick(InputAction.CallbackContext input)
    {
        if (_currentStory.canContinue || _currentStory.currentChoices.Count > 0)
        {
            LoadTextAnim();
        }
        else if (_currentStory.currentChoices.Count == 0)
        {
            loadingText = false;
            panelsTexts[index].text = currentText;
        }
    }

    private void OnDisable()
    {
        _leftClick.Disable();
        _leftClick.performed -= OnClick;
    }
}
