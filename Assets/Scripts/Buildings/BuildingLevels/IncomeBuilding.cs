using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncomeBuilding", menuName = "Building Types/Income Building")]
public class IncomeBuilding : BuildingLevel
{
    [Space, Header("Income Building Info")]
    [SerializeField] private Resources resourcesToRun;
    [SerializeField] private int resourceCount;
    [SerializeField] private float moralOutputPercentage;

    public override float DailyEarnings(List<Villager> villagers)
    {
        int earnings = 0;

        foreach (var villager in villagers)
        {
            earnings += villager.incomeProfit;
        }

        var rAmt = 0;

        if (villagers.Count > 0)
        {
            rAmt = ServiceLocator.Get<ResourceManager>().UseResources(resourcesToRun, resourceCount);
        }

        return earnings * (rAmt / resourceCount);
    }

    public override void LevelUp(Building building)
    {
        building.ChangeBuilding(buildingNextLevel);
    }
}
