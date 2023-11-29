using UnityEngine;
using TMPro;

public class AllocateVillagers : MonoBehaviour
{
    private GameLoader loader = null;
    private VillageManager vm = null;
    private ResourceManager rm = null;
    [SerializeField] private Building building;
    [SerializeField] private TextMeshProUGUI villagersCount;
    [SerializeField] private TextMeshProUGUI resourcesCount;
    [SerializeField] private TextMeshProUGUI buildingLevel;
    [SerializeField] private EndOfWeekPanel endOfWeekPanel;

    private bool initialized = false;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void OnEnable()
    {
        if (!initialized)
        {
            return;
        }
        buildingLevel.text = building.GetLevel().ToString();
        endOfWeekPanel.UpdateVillagersNums();
        villagersCount.text = building.GetPeopleAmt().ToString() + "/" + building.GetMaxVillagers().ToString();
    }

    private void Initialize()
    {
        Debug.Log($"{nameof(Initialize)}");

        vm = ServiceLocator.Get<VillageManager>();
        rm = ServiceLocator.Get<ResourceManager>();
        
        initialized = true;
    }

    public void ChangeVillagersNum(int villagerAmt)
    {
        vm.AllocateVillager(building, villagerAmt);
        villagersCount.text = building.GetPeopleAmt().ToString() + "/" + building.GetMaxVillagers().ToString();
        endOfWeekPanel.UpdateVillagersNums();
    }

    public void ChangeResourceNum(int resourceAmt)
    {
        rm.AddResource(building.GetResoureType() ,resourceAmt);
        resourcesCount.text = rm.GetResourceAmt(building.GetResoureType()).ToString();
        endOfWeekPanel.UpdateResources();
    }
}
