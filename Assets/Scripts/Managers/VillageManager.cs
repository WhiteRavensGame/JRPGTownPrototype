using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private int _vTotal;
    private int _vAllocated;
    private int _extraVillagers;

    private ResourceManager _rm = null;

    private Dictionary<Building, int> _villagerAllocation = new Dictionary<Building, int>();
    private List<Building> _buildings = new List<Building>();
    
    public void InitializeBuildings(List<Building> buildings)
    {
        for (int i = 0; i < 6; i++)
        {
            _villagerAllocation.Add(buildings[i], 0);
            _buildings.Add(buildings[i]);
        }

        _rm = ServiceLocator.Get<ResourceManager>();
    }

    //increase villagers that are in the town
    public void AddVillagers(int amount)
    {
        _vTotal += amount;
    }

    #region Allocate Villagers to Buildings
    public void AllocateVillager(Building building, int amount)
    {
        if (_villagerAllocation[building] + amount > building.GetMaxVillagers())
        {
            return;
        }
        else if (_vAllocated + amount > _vTotal)
        {
            return;
        }
        else if (_extraVillagers <= 0 && amount > 0)
        {
            return;
        }

        _villagerAllocation[building] += amount;
        _vAllocated += amount;
        building.EditPeople(amount);
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

    public void EndDayAllocationStart(int villagersAmt)
    {
        foreach(var building in _buildings)
        {
            building.ActivateAllocationButtons(true);
        }

        ServiceLocator.Get<PlayerManager>().gameState = GameStates.EndOfDay;
        _extraVillagers += villagersAmt;
    }

    public int GetExtraVillagers()
    {
        return _extraVillagers;
    }
}
