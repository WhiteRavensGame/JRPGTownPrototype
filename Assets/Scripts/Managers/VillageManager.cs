using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    //all the different types of buildings present in the village will be here
    //the amount of villagers for allocating villagers will also be here

    private int _morale;

    private int _vTotal;
    private int _vAllocated;

    private Dictionary<BuildingType, int> _villagerAllocation = new Dictionary<BuildingType, int>();
    private Dictionary<BuildingType, Building> _buildings = new Dictionary<BuildingType, Building>();

    #region IGameModule Implementation
    public bool IsInitialized { get { return _isInitialized; } }
    private bool _isInitialized = false;

    public IEnumerator LoadModule()
    {
        Debug.Log("Loading Village Manager");

        InitializeVillage();
        yield return new WaitUntil(() => { return IsInitialized; });

        ServiceLocator.Register<VillageManager>(this);
        yield return null;
    }
    private void InitializeVillage()
    {
        _isInitialized = true;
    }
    #endregion

    

    public void InitializeBuildings(List<Building> buildings)
    {
        for (int i = 0; i < 6; i++)
        {
            _villagerAllocation.Add((BuildingType)i, 0);
            _buildings.Add(buildings[i].GetBuildingType(), buildings[i]);
        }
    }


    //increase villagers that are in the town
    public void AddVillagers(int amount)
    {
        _vTotal += amount;
    }

    #region Allocate Villagers to Buildings
    public void AddVillager(BuildingType buildingType, int amount)
    {
        if (_villagerAllocation[buildingType] + amount > _buildings[buildingType].GetMaxVillagers())
            return;
        if (_vAllocated + amount > _vTotal)
            return;

        _villagerAllocation[buildingType] += amount;
        _vAllocated += amount;
    }

    public void RemoveVillager(BuildingType buildingType, int amount)
    {
        if (_villagerAllocation[buildingType] - amount < 0)
            return;
        if (_vAllocated - amount < 0)
            return;

        _villagerAllocation[buildingType] -= amount;
        _vAllocated -= amount;
    }

    #endregion
}
