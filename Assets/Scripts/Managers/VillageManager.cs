using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private int _morale;
    private int _defense;
    private int _reputation;

    private int _vTotal = 4;
    private int _vAllocated = 0;

    private ResourceManager _rm = null;
    private UIManager _ui = null;

    private Dictionary<Building, int> _villagerAllocation = new Dictionary<Building, int>();
    
    public void Initialize(List<Building> buildings, UIManager ui)
    {
        for (int i = 0; i < 6; i++)
        {
            _villagerAllocation.Add(buildings[i], 0);
        }

        _rm = ServiceLocator.Get<ResourceManager>();
        _ui = ui;
        UpdateVillagerText();
    }

    //increase villagers that are in the town
    public void AddVillagers(int amount)
    {
        _vTotal += amount;
        UpdateVillagerText();
    }

    #region Allocate Villagers to Buildings
    public void AllocateVillager(Building building, int amount)
    {
        if (_villagerAllocation[building] + amount > building.GetMaxVillagers())
        {
            return;
        }
        if (_vAllocated + amount > _vTotal)
        {
            return;
        }

        _villagerAllocation[building] += amount;
        _vAllocated += amount;
        building.EditPeople(amount);
        UpdateVillagerText();
    }

    #endregion

    public bool UpgradeBuilding(Building building)
    {
        int upgradeCost = building.GetUpgradeCost();

        if (_rm.CanUseGold(upgradeCost))
        {
            _rm.TakeGold(upgradeCost);
            return true;
        }

        return false;
    }

    public int GetAllocatedVillagers(Building building)
    {
        return _villagerAllocation[building];
    }

    private void UpdateVillagerText()
    {
        int total = _vTotal;
        int left = _vTotal - _vAllocated;

        _ui.UpdateVillagerCount(total, left);
    }
}
