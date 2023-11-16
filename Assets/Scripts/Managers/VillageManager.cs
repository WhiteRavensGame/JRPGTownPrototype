using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private int _vTotal = 4;
    private int _vAllocated = 0;

    private ResourceManager _rm = null;
    private UIManager _ui = null;

    private List<Building> _buildings = new List<Building>();

    [SerializeField] private List<Villager> villagers;
    
    public void Initialize(List<Building> buildings, UIManager ui, List<Villager> villagers)
    {
        for (int i = 0; i < 6; i++)
        {
            _buildings.Add(buildings[i]);
        }
        for (int i = 0; i < villagers.Count; i++)
        {
            villagers.Add(villagers[i]);
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
        if (building.GetPeopleAmt() + amount > building.GetMaxVillagers())
        {
            return;
        }
        else if (_vAllocated + amount > _vTotal || building.GetPeopleAmt() + amount < 0)
        {
            return;
        }

        _vAllocated += amount;
        building.EditPeople(villagers[0], amount > 0);
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

    private void UpdateVillagerText()
    {
        int total = _vTotal;
        int left = _vTotal - _vAllocated;

        _ui.UpdateVillagerCount(total, left);
    }

    public void EndDayAllocationStart(int villagersAmt)
    {
        foreach(var building in _buildings)
        {
            building.ActivateAllocationButtons(true);
        }

        _vTotal += villagersAmt;
        UpdateVillagerText();
    }

    public string GetVillagersAmt()
    {
        return (_vTotal - _vAllocated).ToString() + "/" + _vTotal.ToString();
    }
}
