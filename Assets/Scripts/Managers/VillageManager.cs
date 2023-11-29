using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private int _vTotal = 0;
    private int _vAllocated = 0;

    private ResourceManager _rm = null;
    private UIManager _ui = null;

    [SerializeField] private List<Villager> villagers;

    private List<Building> _buildings = new List<Building>();

    private List<GameObject> _villagersObj = new();
    [SerializeField] private Vector2 _villagersSpawn;

    public void Initialize(List<Building> buildings, UIManager ui, List<Villager> newVillagers)
    {
        if(!ServiceLocator.Get<GameManager>().LoadGame)
        {
            _vTotal = 4;
        }
        for (int i = 0; i < buildings.Count; ++i)
        {
            _buildings.Add(buildings[i]);
            _vTotal += buildings[i].GetPeopleAmt();
            _vAllocated += buildings[i].GetPeopleAmt();
        }
        for (int i = 0; i < newVillagers.Count; ++i)
        {
            villagers.Add(newVillagers[i]);
        }

        for (int i = 0; i < newVillagers.Count; ++i)
        {
            villagers.Add(newVillagers[i]);
        }

        _rm = ServiceLocator.Get<ResourceManager>();
        _ui = ui;
        UpdateVillagerText();
        InstantiateVillagers();
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

        _ui.UpdateVillagerCount(left, total);
    }

    public void EndDayAllocationStart(int villagersAmt)
    {
        _vTotal += villagersAmt;
        UpdateVillagerText();
    }

    public string GetVillagersAmt()
    {
        return (_vTotal - _vAllocated).ToString() + "/" + _vTotal.ToString();
    }

    public void InstantiateVillagers()
    {
        var villagerObj = ServiceLocator.Get<PrefabManager>().AIVillager;
        int count = _villagersObj.Count;

        for (int i = 0; i < _vTotal - count; ++i)
        {
            var villager = Instantiate(villagerObj, _villagersSpawn, Quaternion.identity);
            villager.GetComponent<VillagerAI>().Initialize(_buildings);
            _villagersObj.Add(villager);
        }
    }

    public void DeleteVillagers()
    {
        int count = _villagersObj.Count;

        for (int i = count; i > _vTotal; --i)
        {
            Destroy(_villagersObj[i - 1]);
            _villagersObj.RemoveAt(i - 1);
        }
    }
}
