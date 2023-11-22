using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingLevel: ScriptableObject
{
    [Header("Building Settings")]
    [SerializeField] protected BuildingLevel buildingNextLevel;
    [SerializeField] protected Resources resourcesToProduce;
    [SerializeField] protected Sprite buildingSprite;
    [SerializeField] protected int maxVillagers;
    [SerializeField] protected int maxIncome;
    [SerializeField] protected int minIncome;
    [SerializeField] protected int upgradeCost;

    [Space, Header("Panel Settings")] 
    [SerializeField, TextArea(3, 10)] protected string panelText; 
    [SerializeField] protected string minCitizensText;
    [SerializeField] protected string minOutput;
    [SerializeField] protected string maxCitizensText;
    [SerializeField] protected string maxOutput;
    [SerializeField] protected Sprite vendorImage;

    public BuildingLevel getNextLevelBuilding { get { return buildingNextLevel; } }
    public Sprite getbuildingSprite { get { return buildingSprite; } }
    public int getMaxVillagers { get { return maxVillagers; } }
    public int getUpgradeCost { get { return upgradeCost; } }
    public Resources getResources { get { return resourcesToProduce; } }
    public int getMaxIncome { get { return maxIncome; } }
    public int getMinIncome { get { return minIncome; } }

    public string getPanelText { get { return panelText; } }
    public string getMinCitizensText { get { return minCitizensText; } }
    public string getMinOutput { get { return minOutput; } }
    public string getMaxCitizensText { get { return maxCitizensText; } }
    public string getMaxOutput { get { return maxOutput; } }
    public Sprite getVendorImage { get { return vendorImage; } }

    public abstract float DailyEarnings(List<Villager> currentVillagersNum);
    public abstract void LevelUp(Building building);
}