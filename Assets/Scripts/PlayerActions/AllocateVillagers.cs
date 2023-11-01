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

    public void SetVillagerFood()
    {
        vm.AddVillagerFood(1);
    }

    public void SetVillagerMaterial()
    {
        vm.AddVillagerMaterial(1);
    }

    public void SetVillageCloth()
    {
        vm.AddVillagerCloth(1);
    }

    public void RemoveVillagerFood()
    {
        vm.RemoveVillagerFood(1);
    }

    public void RemoveVillagerMaterial()
    {
        vm.RemoveVillagerMaterial(1);
    }

    public void RemoveVillageCloth()
    {
        vm.RemoveVillagerCloth(1);
    }
}
