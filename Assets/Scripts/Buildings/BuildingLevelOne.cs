using UnityEngine;

enum Resources { Food, Clothes, RawMaterials }

[CreateAssetMenu(fileName = "BuildingLevel1", menuName = "BuildingLevels/BuildingLevel1")]
public class BuildingLevelOne : BuildingLevel
{
    [SerializeField]
    private uint monyToLevelUp;

    public override void Execute()
    {
        Debug.Log("Method colled 1");
    }
}