using UnityEngine;

[CreateAssetMenu(fileName = "WormFarmLevel", menuName = "Building Levels/Worm Farm Level")]
public class WormFarmLevel : BuildingLevel
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
