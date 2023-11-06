using System.Collections.Generic;
using UnityEngine;

public enum Resources { Fish, Iron, Silk, Gold }

public abstract class BuildingLevel: ScriptableObject
{
    [Header("Building Settings")]
    [SerializeField] protected BuildingLevel buildingNextLevel;
    [SerializeField] protected Resources resourcesToProduce;
    [SerializeField] protected Sprite buildingSprite;
    [SerializeField] protected int villagersNeeded;
    [SerializeField] protected int income;
    [SerializeField] protected int upgradeCost;

    [Space, Header("Panel Settings")] 
    [SerializeField, TextArea(3, 10)] protected string panelText; 
    [SerializeField, TextArea(3, 10)] protected string minResourcesInfo;
    [SerializeField, TextArea(3, 10)] protected string maxResourcesInfo;
    [SerializeField] protected Sprite vendorImage;

    public Sprite getbuildingSprite { get { return buildingSprite; } }
    public int getVillagersNeeded { get { return villagersNeeded; } }
    public int getUpgradeCost { get { return upgradeCost; } }
    public Resources getResources { get { return resourcesToProduce; } }
    public int getIncome { get { return income; } }

    public string getPanelText { get { return panelText; } }
    public string getMinResourcesInfo { get { return minResourcesInfo; } }
    public string getMaxResourcesInfo { get { return maxResourcesInfo; } }
    public Sprite getVendorImage { get { return vendorImage; } }

    public abstract float DailyEarnings(int currentVillagersNum);
    public abstract void LevelUp(Building building);
}