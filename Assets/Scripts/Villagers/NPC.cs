using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameLoader _loader;
    private ReputationManager _reputation;

    [SerializeField] private Building _attachedBuilding;

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

        _attachedBuilding.AttachedNPC = this;
    }

    public void ExtractionReputation()
    {
        _reputation.BuildingUpgrade(_id, 13.3f);
    }

    public void IncomeReputation()
    {
        _reputation.BuildingUpgrade(_id, 40f);
    }
}
