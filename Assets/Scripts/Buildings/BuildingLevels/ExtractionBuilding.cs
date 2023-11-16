using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExtractionBuilding", menuName = "Building Types/Extraction Building")]
public class ExtractionBuilding : BuildingLevel
{
    public override float DailyEarnings(List<Villager> villagers)
    {
        int earnings = 0;

        foreach (var villager in villagers)
        {
            earnings += villager.resourceProfit;

            if(resourcesToProduce == villager.areaOfEfficiency)
            {
                earnings += (int)villager.efficiency;
            }
        }

        return earnings;
    }

    public override void LevelUp(Building building)
    {
        if (buildingNextLevel != null)
        {
            building.ChangeBuilding(buildingNextLevel);
        }
    }
}
