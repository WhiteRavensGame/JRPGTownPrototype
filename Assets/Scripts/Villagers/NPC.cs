using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private GameLoader _loader;
    private ReputationManager _reputation;

    [SerializeField] private Building _attachedBuilding;
    [SerializeField] private Building _silkLadyExtraBuilding;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _silderFillImage;
    [SerializeField] private Color lowColor = Color.red;
    [SerializeField] private Color hightColor = Color.green;
    public bool silkLady = false;

    public string Name;

    private void Awake()
    {
        _loader = ServiceLocator.Get<GameLoader>();
        _loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        _reputation = ServiceLocator.Get<ReputationManager>();
        _reputation.AddNPC(this);
        _slider.onValueChanged.AddListener(UpdateColor);
        UpdateColor(_slider.value);

        if (_attachedBuilding != null)
        {
            _attachedBuilding.AttachedNPC = this;
        }
        if (_silkLadyExtraBuilding != null && silkLady)
        {
            _silkLadyExtraBuilding.AttachedNPC = this;
        }
    }

    public void ExtractionReputation()
    {
        if (silkLady)
        {
            _reputation.BuildingUpgrade(Name, 9f);
        }
        else
        {
            _reputation.BuildingUpgrade(Name, 18f);
        }
        _slider.value = _reputation.GetReputation(Name) / 100f;
    }

    public void IncomeReputation()
    {
        if (silkLady)
        {
            _reputation.BuildingUpgrade(Name, 22.5f);
        }
        else
        {
            _reputation.BuildingUpgrade(Name, 45f);
        }
        _slider.value = _reputation.GetReputation(Name) / 100f;       
        
    }
    private void UpdateColor(float value)
    {
        _silderFillImage.color = Color.Lerp(lowColor, hightColor, _reputation.GetReputation(Name) / 100f);
    }

    public void ChangeReputation(int amount)
    {
        
    }
}
