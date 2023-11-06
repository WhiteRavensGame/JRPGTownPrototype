using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private int _morale;
    private int _defense;
    private int _reputation;

    private int _vTotal;
    private int _vAllocated;

    private ResourceManager _rm = null;

    private Dictionary<BuildingType, int> _villagerAllocation = new Dictionary<BuildingType, int>();
    private Dictionary<BuildingType, Building> _buildings = new Dictionary<BuildingType, Building>();
    
    public void InitializeBuildings(List<Building> buildings)
    {
        for (int i = 0; i < 6; i++)
        {
            _villagerAllocation.Add((BuildingType)i, 0);
            _buildings.Add(buildings[i].GetBuildingType(), buildings[i]);
        }

        _rm = ServiceLocator.Get<ResourceManager>();
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

    public bool UpgradeBuilding(BuildingType buildingType)
    {
        int upgradeCost = _buildings[buildingType].GetUpgradeCost();

        if (_rm.CanUseGold(upgradeCost))
        {
            _rm.TakeGold(upgradeCost);
            return true;
        }

        return false;
    }

    public int GetAllocatedVillagers(BuildingType type)
    {
        return _villagerAllocation[type];
    }
}
