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
        int earningPerVillager = maxIncome / maxVillagers;

        foreach (var villager in villagers)
        {
            earnings += (int)(earningPerVillager * villager.incomeMultiplier);
        }

        var rAmt = 0;
        if (ServiceLocator.Get<PlayerManager>().AllocatingVillagers)
        {
            rAmt = resourceCount;
        }
        else if (villagers.Count > 0)
        {
            rAmt = ServiceLocator.Get<ResourceManager>().UseResources(resourcesToRun, resourceCount);
        }

        return earnings * (rAmt / resourceCount);
    }

    public override void LevelUp(Building building)
    {
        building.ChangeBuilding(buildingNextLevel);
    }

    public override int GetResourcesToRun()
    {
        return resourceCount;
    }
}
