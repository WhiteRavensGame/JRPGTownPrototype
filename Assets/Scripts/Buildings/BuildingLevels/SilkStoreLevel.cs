using UnityEngine;

[CreateAssetMenu(fileName = "SilkStoreLevel", menuName = "Building Levels/Silk Store Level")]
public class SilkStoreLevel : BuildingLevel
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
