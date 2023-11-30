using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInitialization : MonoBehaviour
{
    [SerializeField] private List<Building> buildings;
    [SerializeField] private UIManager ui;
    [SerializeField] private List<Villager> villagers;

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
    }
}
