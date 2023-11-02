using UnityEngine;

[CreateAssetMenu(fileName = "FisheryLevel", menuName = "Building Levels/Fishery Level")]
public class FisheryLevel : BuildingLevel
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
