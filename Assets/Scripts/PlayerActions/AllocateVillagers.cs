using UnityEngine;

public class AllocateVillagers : MonoBehaviour
{
    private GameLoader loader = null;
    private VillageManager vm = null;
    [SerializeField] private Building building;

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

    public void ChangeVillagersNum(int villagerAmt)
    {
        vm.AllocateVillager(building, villagerAmt);
    }
}
