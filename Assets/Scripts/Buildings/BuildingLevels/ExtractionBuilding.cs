using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExtractionBuilding", menuName = "Building Types/Extraction Building")]
public class ExtractionBuilding : BuildingLevel
{
    public override void Execute()
    {
        Debug.Log("Method colled 1");
    }

    public override void LevelUp(Building building)
    {
        if (buildingNextLevel != null)
        {
            building.ChangeBuilding(buildingNextLevel);
        }
    }

    public override KeyValuePair<Resources, int> CalculateDayEarning(Building building)
    {
        Resources resource = getResources;
        int villagers = vm.GetAllocatedVillagers(building.GetBuildingType());
        int income = getIncome;

        if (villagers == 0)
        {
            income = 0;
        }
        else
        {
            int missingVillagers = getMaxVillagers - villagers;
            income -= missingVillagers * 5;
        }

        return new KeyValuePair<Resources, int>(resource, income);
    }
}
