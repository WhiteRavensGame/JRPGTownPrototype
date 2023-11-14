using UnityEngine;
using TMPro;

public class AllocateVillagers : MonoBehaviour
{
    private GameLoader loader = null;
    private VillageManager vm = null;
    [SerializeField] private Building building;
    [SerializeField] private TextMeshProUGUI villagersCount;
    [SerializeField] private EndOfWeekPanel endOfWeekPanel;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
        villagersCount.text = building.GetPeopleAmt().ToString() + "/" + building.GetMaxVillagers().ToString();
    }

    private void OnEnable()
    {
        endOfWeekPanel.UpdateVillagersNums();
    }

    private void Initialize()
    {
        Debug.Log($"{nameof(Initialize)}");

        vm = ServiceLocator.Get<VillageManager>();
    }

    public void ChangeVillagersNum(int villagerAmt)
    {
        vm.AllocateVillager(building, villagerAmt);
        villagersCount.text = building.GetPeopleAmt().ToString() + "/" + building.GetMaxVillagers().ToString();
        endOfWeekPanel.UpdateVillagersNums();
    }
}
