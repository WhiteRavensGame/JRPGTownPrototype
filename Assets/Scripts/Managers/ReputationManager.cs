using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    private List<int> _reputationList = new List<int>();

    public int AddNPC()
    {
        _reputationList.Add(0);
        return _reputationList.Count - 1;
    }

    public void AddReputation(int id, int amount)
    {
        _reputationList[id] += amount;
    }

    public int GetReputation(int id)
    {
        return _reputationList[id];
    }
}
