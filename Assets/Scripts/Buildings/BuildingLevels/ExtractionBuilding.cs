using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExtractionBuilding", menuName = "Building Types/Extraction Building")]
public class ExtractionBuilding : BuildingLevel
{
    public override float DailyEarnings(int currentVillagersNum)
    {
        if(currentVillagersNum < villagersNeeded)
        {
            return 0;
        }
        else
        {
            return income;
        }
    }

    public override void LevelUp(Building building)
    {
        if (buildingNextLevel != null)
        {
            building.ChangeBuilding(buildingNextLevel);
        }
    }
}
