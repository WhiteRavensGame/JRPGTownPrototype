using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    private VillageManager vm = null;

    [HideInInspector] public NPC AttachedNPC { get; set; }

    [Header("Building Settings")]
    [SerializeField] private BuildingType buildingType;
    [SerializeField] private BuildingLevel buildingLevelInfo;
    [SerializeField] private BuildingUpgradeInfo _buildingUpgrade;
    [SerializeField] private int buildingLevel;
    [SerializeField] private int buildingMaxLevel;

    private SpriteRenderer _buildingSR;
    [SerializeField] private List<Villager> _currentPeople;

    [Space, Header("Panel Settings")]
    [SerializeField] private GameObject infoPanel;

    [Space, Header("Extra Settings")]
    [SerializeField] private string buildingSaveName;

    public bool HasProduced { get; set; } = false;
    
    public void Initialize()
    {
        vm = ServiceLocator.Get<VillageManager>();
        _buildingSR = GetComponent<SpriteRenderer>();

        if (ServiceLocator.Get<GameManager>().LoadGame)
        {
            Load();
        }

        ChangeBuilding(buildingLevelInfo);
    }

    public void ActivatePanel(bool activation)
    {
        infoPanel.SetActive(activation);
    }

    public void ChangeBuilding(BuildingLevel newLevel)
    {
        buildingLevelInfo = newLevel;
        _buildingUpgrade.UpdateResources();
    }

    public KeyValuePair<Resources, int> GetBuildingsEarnings()
    {
        int rAmt = (int)buildingLevelInfo.DailyEarnings(_currentPeople);

        if (ServiceLocator.Get<TimeManager>().IsWeekOne() && 
            ServiceLocator.Get<GodModifier>().Modification == GodModification.DoubleProduction)
        {
            rAmt *= 2;
        }
        if (rAmt > 0)
        {
            HasProduced = true;
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

        if (AttachedNPC != null)
        {
            if ((int)buildingType < 3)
            {
                AttachedNPC.IncomeReputation();
            }
            else
            {
                AttachedNPC.ExtractionReputation();
            }
        }

        //make building upgrade also level up
    }

    public int GetMaxVillagers()
    {
        return buildingLevelInfo.getMaxVillagers;
    }

    public int GetNextMaxVillagers()
    {
        if (buildingLevelInfo.GetNextLevel != null)
        {
            return buildingLevelInfo.GetNextLevel.getMaxVillagers;
        }
        else
        {
            return 0;
        }
    }

    public BuildingType GetBuildingType()
    {
        return buildingType;
    }

    public int GetUpgradeCost()
    {
        return buildingLevelInfo.getUpgradeCost;
    }

    public void EditPeople(Villager villager, bool isAdding)
    {
        if (isAdding)
        {
            _currentPeople.Add(villager);
        }
        else
        {
            _currentPeople.RemoveAt(0);
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

    public int GetLevel()
    {
        return buildingLevel;
    }

    public BuildingLevel GetBuildingLevelInfo()
    {
        return buildingLevelInfo;
    }

    public void Load()
    {
        var newData = ServiceLocator.Get<SaveSystem>().Load<BuildingSave>("B" + buildingSaveName + "save.doNotOpen");
        if (!EqualityComparer<BuildingSave>.Default.Equals(newData, default))
        {
            buildingLevel = newData.buildingLevel;

            foreach (var villagerData in newData.currentPeople)
            {
                var neData = ServiceLocator.Get<PrefabManager>().EmptyVillager;
                var newVillager = neData.GetComponent<Villager>();
                newVillager.LoadData(villagerData);
                _currentPeople.Add(newVillager);
            }

            for (int i = 1; i < buildingLevel; ++i)
            {
                buildingLevelInfo = buildingLevelInfo.getNextLevelBuilding;
            }
        }
    }

    [ContextMenu("TestSave")]
    public void Save()
    {
        BuildingSave saveBuilding = new BuildingSave();
        saveBuilding.buildingLevel = buildingLevel;
        saveBuilding.currentPeople = new List<VillagerSaveData>();
        foreach (var v in _currentPeople)
        {
            saveBuilding.currentPeople.Add(v.ToSaveData());
        }
        ServiceLocator.Get<SaveSystem>().Save<BuildingSave>(saveBuilding, "B" + buildingSaveName + "save.doNotOpen");
    }

    [System.Serializable]
    private class BuildingSave
    {
        public int buildingLevel;
        public List<VillagerSaveData> currentPeople;
    }
}
