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
}
