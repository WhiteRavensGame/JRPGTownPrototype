using UnityEngine;

[CreateAssetMenu(fileName = "InnLevel", menuName = "Building Levels/Inn Level")]
public class InnLevel : BuildingLevel
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
