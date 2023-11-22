using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInitialization : MonoBehaviour
{
    [SerializeField] List<Building> buildings;
    [SerializeField] UIManager ui;
    [SerializeField] List<Villager> villagers;
    [SerializeField] private TimeManager _timeManager;

    private GameLoader loader = null;
    
    private VillageManager village = null;
    private EarningsManager earnings = null;
    private ResourceManager resources = null;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        village = ServiceLocator.Get<VillageManager>();
        earnings = ServiceLocator.Get<EarningsManager>();
        resources = ServiceLocator.Get<ResourceManager>();

        village.Initialize(buildings, ui, villagers);
        earnings.InitializeBuildings(buildings);
        resources.Initialize(ui);

        for (int i = 0; i <  buildings.Count; i++)
        {
            buildings[i].TimeManager = _timeManager;
        }
    }
}
