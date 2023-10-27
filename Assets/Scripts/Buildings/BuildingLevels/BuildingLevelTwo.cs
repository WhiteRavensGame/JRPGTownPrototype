using UnityEngine;

[CreateAssetMenu(fileName = "BuildingLevel2", menuName = "BuildingLevels/BuildingLevel2")]
public class BuildingLevelTwo : BuildingLevel
{
    [Space, Header("Level Two Settings")]
    [SerializeField]
    private uint amoutOfFoodNeeded;

    public override void Execute() 
    {
        Debug.Log("Method colled 2");
    }

    public override void LevelUp(Building building)
    {
        Debug.Log("Method colled 2");
    }
}
