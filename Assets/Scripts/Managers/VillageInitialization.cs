using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInitialization : MonoBehaviour
{
    [SerializeField] List<Building> buildings;
    [SerializeField] UIManager ui;
    [SerializeField] List<Villager> villagers;
    [SerializeField] private TimeManager _timeManager;

    private VillageManager village = null;
    private EarningsManager earnings = null;
    private ResourceManager resources = null;

    public void Initialize()
    {
        village = ServiceLocator.Get<VillageManager>();
        earnings = ServiceLocator.Get<EarningsManager>();
        resources = ServiceLocator.Get<ResourceManager>();

        foreach (var building in buildings)
        {
            building.Initialize();
        }

        earnings.InitializeBuildings(buildings);
        resources.Initialize(ui);
        village.Initialize(buildings, ui, villagers);

        for (int i = 0; i < buildings.Count; i++)
        {
            buildings[i].TimeManager = _timeManager;
        }
    }
}
