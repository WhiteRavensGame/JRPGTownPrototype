using UnityEngine;

[CreateAssetMenu(fileName = "BuildingLevel2", menuName = "BuildingLevels/BuildingLevel2")]
public class BuildingLevelTwo : BuildingLevel
{
    [SerializeField]
    private uint amoutOfFoodNeeded;

    public override void Execute() 
    {
        Debug.Log("Method colled 2");
    }
}
