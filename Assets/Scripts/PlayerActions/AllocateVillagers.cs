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

    public void SetVillagerInn()
    {
        vm.AddVillagerInn(1);
    }

    public void SetVillagerSmith()
    {
        vm.AddVillagerSmith(1);
    }

    public void SetVillageSilk()
    {
        vm.AddVillagerSilk(1);
    }

    public void RemoveVillagerInn()
    {
        vm.RemoveVillagerInn(1);
    }

    public void RemoveVillagerSmith()
    {
        vm.RemoveVillagerSmith(1);
    }

    public void RemoveVillageSilk()
    {
        vm.RemoveVillagerSilk(1);
    }
}
