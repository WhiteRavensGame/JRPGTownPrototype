using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    VillageManager vm = null;

    [Header("Building Settings")]
    [SerializeField] private BuildingType buildingType;
    [SerializeField] private BuildingLevel buildingLevelInfo;
    [SerializeField] private int buildingLevel;
    [SerializeField] private int buildingMaxLevel;

    private SpriteRenderer buildingSR;

    [Space, Header("Panel Settings")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image vendorImage;
    [SerializeField] private TextMeshProUGUI storeName;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private TextMeshProUGUI minResourcesInfo;
    [SerializeField] private TextMeshProUGUI maxResourcesInfo;

    private void Awake()
    {
        vm = ServiceLocator.Get<VillageManager>();
        buildingSR = GetComponent<SpriteRenderer>();
        ChangeBuilding(buildingLevelInfo);
    }

    public void ActivatePanel(bool activation)
    {
        infoPanel.SetActive(activation);
    }

    public void ChangeBuilding(BuildingLevel newLevel)
    {
        buildingLevelInfo = newLevel;

        panelText.text = buildingLevelInfo.getPanelText;
        vendorImage.sprite = buildingLevelInfo.getVendorImage;
        storeName.text = buildingLevelInfo.getVendorImage.name;
        minResourcesInfo.text = buildingLevelInfo.getMinResourcesInfo;
        maxResourcesInfo.text = buildingLevelInfo.getMaxResourcesInfo;

        buildingSR.sprite = buildingLevelInfo.getbuildingSprite;
    }

    public void Execute()
    {
        buildingLevelInfo.Execute();
    }

    public void LevelUp()
    {
        if (vm.UpgradeBuilding(buildingType))
        {
            buildingLevelInfo.LevelUp(this);
        }
    }

    public int GetMaxVillagers()
    {
        return buildingLevelInfo.getMaxVillagers;
    }

    public BuildingType GetBuildingType()
    {
        return buildingType;
    }

    public int GetUpgradeCost()
    {
        return buildingLevelInfo.getUpgradeCost;
    }
}
