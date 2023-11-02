using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InnLevel1", menuName = "Building Levels/Inn Levels/Inn Level 1")]
public class InnLevelOne : BuildingLevel
{
    public override void Execute()
    {
        Debug.Log("Method colled 1");
    }

    public override void LevelUp(Building building)
    {
        building.ChangeBuilding(buildingNextLevel);
    }
}
