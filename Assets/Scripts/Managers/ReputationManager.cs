using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    private List<float> _reputationList = new List<float>();

    //add ten when building is updgraded

    public int AddNPC()
    {
        _reputationList.Add(0);
        return _reputationList.Count - 1;
    }

    public void BuildingUpgrade(int id, float amt)
    {
        _reputationList[id] += amt;
    }
}
