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
    public bool silkLady = false;

    private int _id;

    private void Awake()
    {
        _loader = ServiceLocator.Get<GameLoader>();
        _loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        _reputation = ServiceLocator.Get<ReputationManager>();
        _id = _reputation.AddNPC();

        if (_attachedBuilding != null)
        {
            _attachedBuilding.AttachedNPC = this;
        }
        if (_silkLadyExtraBuilding != null)
        {
            _silkLadyExtraBuilding.AttachedNPC = this;
        }
    }

    public void ExtractionReputation()
    {
        if (silkLady)
        {
            _reputation.BuildingUpgrade(_id, 9f);
        }
        else
        {
            _reputation.BuildingUpgrade(_id, 18f);
        }
    }

    public void IncomeReputation()
    {
        if (silkLady)
        {
            _reputation.BuildingUpgrade(_id, 22.5f);
        }
        else
        {
            _reputation.BuildingUpgrade(_id, 45f);
        }
    }
}
