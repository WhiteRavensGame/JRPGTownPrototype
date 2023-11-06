using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarningsManager : MonoBehaviour
{
    private ResourceManager _rm = null;

    #region IGameModule Implementation
    public bool IsInitialized { get { return _isInitialized; } }
    private bool _isInitialized = false;

    public IEnumerator LoadModule()
    {
        Debug.Log("Loading Day Manager");

        InitializeVillage();
        yield return new WaitUntil(() => { return IsInitialized; });

        ServiceLocator.Register<VillageManager>(this);
        yield return null;
    }
    private void InitializeVillage()
    {
        _rm = ServiceLocator.Get<ResourceManager>();
        _isInitialized = true;
    }
    #endregion

    private List<Building> _buildings;
    List<KeyValuePair<Resources, int>> dailyEarnings;

    public void InitializeBuildings(List<Building> buildings)
    {
        _buildings = buildings;
    }

    public void CalculateEarnings()
    {
        for (int i = 0; i < 6; i++)
        {
            dailyEarnings[i] = _buildings[i].GetBuildingsEarnings();
        }

        for (int i = 0; i < 6; i++)
        {
            _rm.AddResource(dailyEarnings[i].Key, dailyEarnings[i].Value);
        }
    }
}
