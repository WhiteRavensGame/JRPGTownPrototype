using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInitialization : MonoBehaviour
{
    [SerializeField] List<Building> buildings;

    private GameLoader loader = null;
    private VillageManager vm = null;
    private EarningsManager em = null;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        vm = ServiceLocator.Get<VillageManager>();
        em = ServiceLocator.Get<EarningsManager>();
        vm.InitializeBuildings(buildings);
        em.InitializeBuildings(buildings);
    }
}
