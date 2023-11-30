using UnityEngine;
using TMPro;

public class AllocateVillagers : MonoBehaviour
{
    private GameLoader loader = null;
    private VillageManager vm = null;
    [SerializeField] private Building building;
    [SerializeField] private TextMeshProUGUI villagersCount;
<<<<<<< Updated upstream
=======
    [SerializeField] private TextMeshProUGUI resourcesCount;
    [SerializeField] private TextMeshProUGUI buildingLevel;
    [SerializeField] private TextMeshProUGUI resourcesToRun;
    [SerializeField] private TextMeshProUGUI buildingBaseOutput;
    [SerializeField] private TextMeshProUGUI buildingSecondaryOutput;
>>>>>>> Stashed changes
    [SerializeField] private EndOfWeekPanel endOfWeekPanel;
    private BuildingLevel _buildingLevel;

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
<<<<<<< Updated upstream
=======
        _buildingLevel = building.GetBuildingLevelInfo();
        buildingLevel.text = building.GetLevel().ToString();
>>>>>>> Stashed changes
        endOfWeekPanel.UpdateVillagersNums();
        villagersCount.text = building.GetPeopleAmt().ToString() + "/" + building.GetMaxVillagers().ToString();
        buildingBaseOutput.text = building.GetBuildingsEarnings().Value.ToString();
        resourcesToRun.text = _buildingLevel.GetResourcesToRun().ToString();
    }

    private void Initialize()
    {
        Debug.Log($"{nameof(Initialize)}");

        vm = ServiceLocator.Get<VillageManager>();
        
        initialized = true;
    }

    public void ChangeVillagersNum(int villagerAmt)
    {
        vm.AllocateVillager(building, villagerAmt);
        villagersCount.text = building.GetPeopleAmt().ToString() + "/" + building.GetMaxVillagers().ToString();
        endOfWeekPanel.UpdateVillagersNums();
        buildingBaseOutput.text = building.GetBuildingsEarnings().Value.ToString();
    }
<<<<<<< Updated upstream
=======

    public void ChangeResourceNum(int resourceAmt)
    {
        rm.AddResource(building.GetResoureType() ,resourceAmt);
        resourcesCount.text = rm.GetResourceAmt(building.GetResoureType()).ToString();
        endOfWeekPanel.UpdateResources();
        resourcesToRun.text = _buildingLevel.GetResourcesToRun().ToString();

    }
>>>>>>> Stashed changes
}
