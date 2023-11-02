using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlacksmithLevel", menuName = "Building Levels/Blacksmith Level")]
public class BlacksmithLevel : BuildingLevel
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
