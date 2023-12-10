using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Mono.Cecil;

public class MainDialogue : MonoBehaviour
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

    public void Enter(TextAsset jsonAsset)
    {
        _currentStory = new Story(jsonAsset.text);
        CheckFunctions();
        CheckVariables();
        LoadTextAnim();
    }

    private void Exit()
    {
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        loadingText = false;
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
                buttons[i].SetActive(active);
            }
        }
    }

    public void ChooseOption(int index)
    {
        CheckAnswers(false);
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

    private void CheckFunctions()
    {
        _currentStory.BindExternalFunction("ChangeAllResource", (int val) =>
        {
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Gold, val);
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Reputation, val);
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Fish, val);
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Iron, val);
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Moral, val);
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Silk, val);
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Troops, val);
            ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        });

        _currentStory.BindExternalFunction("Changegold", (int val) =>
        {
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Gold, val);
            ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        });

        _currentStory.BindExternalFunction("Changecitizens", (int val) =>
        {
            ServiceLocator.Get<VillageManager>().AddVillagers(val);
            if (val > 0)
            {
                ServiceLocator.Get<VillageManager>().InstantiateVillagers();
            }
            else
            {
                ServiceLocator.Get<VillageManager>().DeleteVillagers();
            }
        });

        _currentStory.BindExternalFunction("Changefood", (int val) =>
        {
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Fish, val);
            ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        });

        _currentStory.BindExternalFunction("Changematerials", (int val) =>
        {
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Iron, val);
            ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        });

        _currentStory.BindExternalFunction("Changesilk", (int val) =>
        {
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Silk, val);
            ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        });

        _currentStory.BindExternalFunction("Changemorale", (int val) =>
        {
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Moral, val);
            ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        });

        _currentStory.BindExternalFunction("Changetroops", (int val) =>
        {
            ServiceLocator.Get<ResourceManager>().AddResource(Resources.Troops, val);
            ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        });

        _currentStory.BindExternalFunction("ChangeVillagerMorale", (int val, string Name) =>
        {
            ServiceLocator.Get<ReputationManager>().BuildingUpgrade(Name, val);
        });

        _currentStory.BindExternalFunction("TempChangeBuildingProduction", (int val, string Name) =>
        {
            ServiceLocator.Get<PrefabManager>().GetBuidlding(Name).ChangeProductionAmt(val);
        });

        _currentStory.BindExternalFunction("TurnProductionOff", (int val, string Name) =>
        {
            ServiceLocator.Get<PrefabManager>().GetBuidlding(Name).RestingDaysLeft = val;
        });

        _currentStory.BindExternalFunction("DiscountOnNextUpgrade", (int val, string Name) =>
        {
            ServiceLocator.Get<PrefabManager>().GetBuidlding(Name).DiscountOnUpgrade = val;
            ServiceLocator.Get<PrefabManager>().GetBuidlding(Name).UpdateResourcesText();
        });

        _currentStory.BindExternalFunction("ChangeResourceAmount", (int val, string Name) =>
        {
            ServiceLocator.Get<ResourceManager>().LoanMoney(Name, val);
        });
    }

    private void CheckVariables()
    {
        if (_currentStory.variablesState["AdelaineMorale"] != null)
        {
            _currentStory.variablesState["AdelaineMorale"] = ServiceLocator.Get<ReputationManager>().GetReputation("Adelaine");
        }
        if (_currentStory.variablesState["LorraineMorale"] != null)
        {
            _currentStory.variablesState["LorraineMorale"] = ServiceLocator.Get<ReputationManager>().GetReputation("Lorraine");
        }
        if (_currentStory.variablesState["OscarMorale"] != null)
        {
            _currentStory.variablesState["OscarMorale"] = ServiceLocator.Get<ReputationManager>().GetReputation("Oscar");
        }
        if (_currentStory.variablesState["WillMorale"] != null)
        {
            _currentStory.variablesState["WillMorale"] = ServiceLocator.Get<ReputationManager>().GetReputation("Will");
        }
        if (_currentStory.variablesState["RaeMorale"] != null)
        {
            _currentStory.variablesState["RaeMorale"] = ServiceLocator.Get<ReputationManager>().GetReputation("RaeMorale");
        }

        if (_currentStory.variablesState["troops"] != null)
        {
            _currentStory.variablesState["troops"] = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Troops);
        }
        if (_currentStory.variablesState["TroopsAssigned"] != null)
        {
            _currentStory.variablesState["TroopsAssigned"] = ServiceLocator.Get<PrefabManager>().GetBuidlding("Smithy").GetPeopleAmt();
        }
        if (_currentStory.variablesState["gold"] != null)
        {
            _currentStory.variablesState["gold"] = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Gold);
        }
        if (_currentStory.variablesState["material"] != null)
        {
            _currentStory.variablesState["material"] = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Iron);
        }
        if (_currentStory.variablesState["food"] != null)
        {
            _currentStory.variablesState["food"] = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Fish);
        }
        if (_currentStory.variablesState["silk"] != null)
        {
            _currentStory.variablesState["silk"] = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Silk);
        }
        if (_currentStory.variablesState["citizen"] != null)
        {
            _currentStory.variablesState["citizen"] = ServiceLocator.Get<VillageManager>().GetVillagersNum();
        }
        if (_currentStory.variablesState["morale"] != null)
        {
            _currentStory.variablesState["morale"] = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Moral);
        }
    }

    private void UnbindVariable()
    {
        _currentStory.UnbindExternalFunction("Changegold");
        _currentStory.UnbindExternalFunction("Changecitizens");
        _currentStory.UnbindExternalFunction("Changefood");
        _currentStory.UnbindExternalFunction("Changematerials");
        _currentStory.UnbindExternalFunction("Changesilk");
        _currentStory.UnbindExternalFunction("Changemorale");
        _currentStory.UnbindExternalFunction("Changetroops");
    }

    private void OnDisable()
    {
        _leftClick.Disable();
        _leftClick.performed -= OnClick;
        UnbindVariable();
    }
}
