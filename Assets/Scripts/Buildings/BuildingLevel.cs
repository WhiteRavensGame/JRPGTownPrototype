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

    public BuildingLevel getNextLevelBuilding { get { return buildingNextLevel; } }
    public Sprite getbuildingSprite { get { return buildingSprite; } }
    public int getMaxVillagers { get { return maxVillagers; } }
    public int getUpgradeCost { get { return upgradeCost; } }
    public Resources getResources { get { return resourcesToProduce; } }
    public int getMaxIncome { get { return maxIncome; } }
    public int getMinIncome { get { return minIncome; } }

    public BuildingLevel GetNextLevel { get { return buildingNextLevel; } }

    public abstract float DailyEarnings(List<Villager> currentVillagersNum);
    public abstract void LevelUp(Building building);

    public abstract int GetResourcesToRun();
}