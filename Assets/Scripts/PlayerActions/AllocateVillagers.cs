using UnityEngine;
using TMPro;

public class AllocateVillagers : MonoBehaviour
{
    private GameLoader loader = null;
    private VillageManager vm = null;
    private ResourceManager rm = null;
    [SerializeField] private Building building;
    [SerializeField] private TextMeshProUGUI villagersCount;
    [SerializeField] private TextMeshProUGUI resourcesText;
    [SerializeField] private TextMeshProUGUI incomeText;
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
        UpdateSecondaryResourceText();
    }

    private void Initialize()
    {
        Debug.Log($"{nameof(Initialize)}");

        vm = ServiceLocator.Get<VillageManager>();
        rm = ServiceLocator.Get<ResourceManager>();
        
        initialized = true;

        UpdateSecondaryResourceText();
    }

    public void ChangeVillagersNum(int villagerAmt)
    {
        vm.AllocateVillager(building, villagerAmt);
        villagersCount.text = building.GetPeopleAmt().ToString() + "/" + building.GetMaxVillagers().ToString();
        endOfWeekPanel.UpdateVillagersNums();

        UpdateIncomeText();
        UpdateSecondaryResourceText();

    }

    private void UpdateIncomeText()
    {
        int amount = building.GetBuildingsEarnings().Value;
        incomeText.text = amount.ToString();
    }

    private void UpdateResourceNeededText()
    {

    }

    private void UpdateSecondaryResourceText()
    {
        if (resourcesText == null)
        {
            return;
        }

        if (building.GetBuildingType() == BuildingType.Blacksmith)
        {
            float smithLevel = building.GetMaxVillagers() * 0.5f;
            float amount = (0.5f * smithLevel * smithLevel) - (0.5f * smithLevel) + 1;
            amount *= building.GetPeopleAmt() / building.GetMaxVillagers();
            resourcesText.text = ((int)amount).ToString();
        }
        else if (building.GetBuildingType() == BuildingType.SilkStore)
        {
            int silkLevel = building.GetLevel();
            float amount = (0.25f * (silkLevel * silkLevel)) - (0.25f * silkLevel) + 0.5f;
            resourcesText.text = amount.ToString();
        }
    }
}
