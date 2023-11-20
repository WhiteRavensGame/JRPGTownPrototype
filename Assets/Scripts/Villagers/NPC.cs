using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameLoader _loader;
    private ReputationManager _reputation;

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
    }

    public void IncreaseReputation(int amount)
    {
        _reputation.AddReputation(_id, amount);
    }

    public void DecreaseReputation(int amount)
    {
        _reputation.AddReputation(_id, -amount);
    }
}
