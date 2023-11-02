using UnityEngine;

[CreateAssetMenu(fileName = "MineLevel", menuName = "Building Levels/Mine Level")]
public class MineLevel : BuildingLevel
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
