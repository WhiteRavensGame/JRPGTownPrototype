using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Resources { Fish, Iron, Silk, Gold }

public abstract class BuildingLevel: ScriptableObject
{
    protected VillageManager vm = null;
    protected ResourceManager rm = null;

    [Header("Building Settings")]
    [SerializeField] protected BuildingLevel buildingNextLevel;
    [SerializeField] private Resources resourcesToProduce;
    [SerializeField] private Sprite buildingSprite;
    [SerializeField] private int maxVillagers;
    [SerializeField] private int income;
    [SerializeField] private int upgradeCost;

    [Space, Header("Panel Settings")] 
    [SerializeField, TextArea(3, 10)] private string panelText; 
    [SerializeField, TextArea(3, 10)] private string minResourcesInfo;
    [SerializeField, TextArea(3, 10)] private string maxResourcesInfo;
    [SerializeField] private Sprite vendorImage;

    public Sprite getbuildingSprite { get { return buildingSprite; } }
    public int getMaxVillagers { get { return maxVillagers; } }
    public int getUpgradeCost { get { return upgradeCost; } }
    public Resources getResources { get { return resourcesToProduce; } }
    public int getIncome { get { return income; } }

    public string getPanelText { get { return panelText; } }
    public string getMinResourcesInfo { get { return minResourcesInfo; } }
    public string getMaxResourcesInfo { get { return maxResourcesInfo; } }
    public Sprite getVendorImage { get { return vendorImage; } }

    public abstract void Execute();
    public abstract void LevelUp(Building building);

    public abstract KeyValuePair<Resources, int> CalculateDayEarning(Building building);
}