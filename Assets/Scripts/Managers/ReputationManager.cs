using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    private Dictionary<string, float> _reputationList = new Dictionary<string, float>();

    public int AddNPC(NPC npc)
    {
        _reputationList.Add(npc.Name, 0f);
        return _reputationList.Count - 1;
    }

    public void BuildingUpgrade(string id, float amt)
    {
        _reputationList[id] += amt;
    }

    public float GetReputation(string id)
    {
        return _reputationList[id];
    }
}
