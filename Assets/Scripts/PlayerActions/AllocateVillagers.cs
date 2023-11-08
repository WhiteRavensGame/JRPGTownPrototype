using UnityEngine;

enum AllocateVillagersNum
{
    removeVillager = -1,
    addVillager = 1
}

public class AllocateVillagers : MonoBehaviour
{
    private GameLoader loader = null;
    private VillageManager vm = null;
    [SerializeField] private Building building;
    [SerializeField] private AllocateVillagersNum villagerAmount;

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

    private void OnMouseDown()
    {
        vm.AllocateVillager(building, (int)villagerAmount);
    }
}
