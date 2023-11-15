using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    GameLoader loader = null;
    VillageManager vm = null;

    [HideInInspector]
    public TimeManager TimeManager { get; set; }

    [Header("Building Settings")]
    [SerializeField] private BuildingType buildingType;
    [SerializeField] private BuildingLevel buildingLevelInfo;
    [SerializeField] private int buildingLevel;
    [SerializeField] private int buildingMaxLevel;

    private SpriteRenderer _buildingSR;
    private List<Villager> _currentPeople;

    [Space, Header("Panel Settings")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image vendorImage;
    [SerializeField] private TextMeshProUGUI storeName;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private TextMeshProUGUI minCitizensText;
    [SerializeField] private TextMeshProUGUI minOutput;
    [SerializeField] private TextMeshProUGUI maxCitizensText;
    [SerializeField] private TextMeshProUGUI maxOutput;

    [Space, Header("Extra Settings")]
    [SerializeField] private GameObject[] allocationButtons;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        vm = ServiceLocator.Get<VillageManager>();

        _buildingSR = GetComponent<SpriteRenderer>();

        ChangeBuilding(buildingLevelInfo);
    }

    public void ActivatePanel(bool activation)
    {
        infoPanel.SetActive(activation);
    }

    public void ActivateAllocationButtons(bool activation)
    {
        allocationButtons[0].SetActive(activation);
        allocationButtons[1].SetActive(activation);
    }

    public void ChangeBuilding(BuildingLevel newLevel)
    {
        buildingLevelInfo = newLevel;

        panelText.text = buildingLevelInfo.getPanelText;
        vendorImage.sprite = buildingLevelInfo.getVendorImage;
        storeName.text = buildingLevelInfo.getVendorImage.name;
        minCitizensText.text = buildingLevelInfo.getMinCitizensText;
        minOutput.text = buildingLevelInfo.getMinOutput;
        maxCitizensText.text = buildingLevelInfo.getMaxCitizensText;
        maxOutput.text = buildingLevelInfo.getMaxOutput;

        _buildingSR.sprite = buildingLevelInfo.getbuildingSprite;
    }

    public KeyValuePair<Resources, int> GetBuildingsEarnings()
    {
        int rAmt = (int)buildingLevelInfo.DailyEarnings(_currentPeople);

        if (TimeManager.IsWeekOne() && GodModifier.Modification == GodModification.DoubleProduction)
        {
            rAmt *= 2;
        }

        var resourcesType = buildingLevelInfo.getResources;
        var dailyEarnings = new KeyValuePair<Resources, int>(resourcesType, rAmt);

        return dailyEarnings;
    }

    public void LevelUp()
    {
        if (buildingLevel < buildingMaxLevel && vm.UpgradeBuilding(this))
        {
            ++buildingLevel;
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

    public void EditPeople(int villager)
    {
        if (villager >= 0)
        {
            for (int i = 0; i < villager; ++i)
            {
                _currentPeople.Add(new Villager());
            }
        }
        else
        {
            for (int i = villager; i > 0; ++i)
            {
                _currentPeople.RemoveAt(0);
            }
        }
    }

    public int GetPeopleAmt()
    {
        return _currentPeople.Count;
    }

    public Resources GetResoureType()
    {
        return buildingLevelInfo.getResources;
    }
}
