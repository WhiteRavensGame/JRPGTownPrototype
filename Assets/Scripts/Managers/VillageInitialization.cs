using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInitialization : MonoBehaviour
{
    [SerializeField] List<Building> buildings;
    [SerializeField] UIManager ui;

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

        village.InitializeBuildings(buildings);
        earnings.InitializeBuildings(buildings);
        resources.Initialize(ui);
    }
}
