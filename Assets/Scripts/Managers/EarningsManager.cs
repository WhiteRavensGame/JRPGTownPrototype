using System.Collections.Generic;
using UnityEngine;

public class EarningsManager : MonoBehaviour
{
    private ResourceManager _rm = null;
    private GodModifier _god = null;
    private Building _silkStore;

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
         
            _rm.AddResource(Resources.Moral, (silkLevel * silkLevel) + 1);
            if (_rm.GetResourceAmt(Resources.Moral) > 100)
            {
                _rm.
            }
            _silkStore.HasProduced = false;
        }

        if (_god && _god.ResourceGod)
        {
            _god.AddResource();
        }

        _rm.UpdateResourceText();
    }
}
