using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInitialization : MonoBehaviour
{
    [SerializeField] List<Building> buildings;

    private GameLoader loader = null;
    private VillageManager vm = null;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        vm = ServiceLocator.Get<VillageManager>();
        vm.InitializeBuildings(buildings);
    }
}
