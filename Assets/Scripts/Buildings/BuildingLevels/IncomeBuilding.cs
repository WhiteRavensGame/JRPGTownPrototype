using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "IncomeBuilding", menuName = "Building Types/Income Building")]
public class IncomeBuilding : BuildingLevel
{
    [Space, Header("Income Building Info")]
    [SerializeField] private Resources resourcesToRun;
    [SerializeField] private int resourceCount;
    [SerializeField] private float moralOutputPercentage;

    public override float DailyEarnings(int currentVillagersNum)
    {
        var income = maxIncome;

        if (currentVillagersNum < maxVillagers)
        {
            income = minIncome * currentVillagersNum;
        }

        var rAmt = ServiceLocator.Get<ResourceManager>().UseResources(resourcesToRun, resourceCount);
        return income * (rAmt / resourceCount);
    }

    public override void LevelUp(Building building)
    {
        building.ChangeBuilding(buildingNextLevel);
    }
}
