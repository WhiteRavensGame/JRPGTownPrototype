using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllocateVillagers : MonoBehaviour
{
    private GameLoader loader = null;
    private VillageManager vm = null;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        Debug.Log($"{nameof(Initialize)}");

        vm = ServiceLocator.Get<VillageManager>();
    }    

    //sample for how to add villager / remove villagers
    public void AddVToInn()
    {
        vm.AddVillager(BuildingType.Inn, 1);
    }

    public void RemoveVFromInn()
    {
        vm.RemoveVillager(BuildingType.Inn, 1);
    }
}
