using System.Collections.Generic;
using UnityEngine;

public class EarningsManager : MonoBehaviour
{
    private ResourceManager _rm = null;
    private GodModifier _god = null;
    private Building _silkStore;
    private Building _blackSmith;

    private List<Building> _buildings;
    List<KeyValuePair<Resources, int>> dailyEarnings = new List<KeyValuePair<Resources, int>>();

    public void InitializeBuildings(List<Building> buildings)
    {
        _buildings = buildings;

        for (int i = 0; i < _buildings.Count; i++)
        {
            dailyEarnings.Add(new KeyValuePair<Resources, int>(_buildings[i].GetResoureType(), 0));
            
            if (buildings[i].GetBuildingType() == BuildingType.SilkStore)
            {
                _silkStore = buildings[i];
            }
            if (buildings[i].GetBuildingType() == BuildingType.Blacksmith)
            {
                _blackSmith = buildings[i];
            }
        }

        _rm = ServiceLocator.Get<ResourceManager>();
    }

    public void InitializeGod(GodModifier modifier)
    {
        _god = modifier;
    }

    public void CalculateEarnings()
    {
        for (int i = 0; i < _buildings.Count; i++)
        {
            dailyEarnings[i] = _buildings[i].GetBuildingsEarnings();
            _rm.AddResource(dailyEarnings[i].Key, dailyEarnings[i].Value);
        }

        if (_silkStore.HasProduced && _rm.GetResourceAmt(Resources.Moral) < 100)
        {
            int silkLevel = _silkStore.GetLevel();
         
            _rm.AddMorale((0.25f * (silkLevel * silkLevel)) - (0.25f * silkLevel) + 0.5f);
            if (_rm.GetResourceAmt(Resources.Moral) > 100)
            {
                _rm.SetMorale(100);
            }
            _silkStore.HasProduced = false;
        }

        if (_blackSmith.HasProduced)
        {
            int smithLevel = _blackSmith.GetPeopleAmt() / 2;

            _rm.AddResource(Resources.Troops,(int)((0.5f * smithLevel * smithLevel) - (0.5f * smithLevel) + 1));
            
            _blackSmith.HasProduced = false;
        }

        if (_god && _god.ResourceGod)
        {
            _god.AddResource();
        }

        _rm.UpdateResourceText();
    }
}
