using UnityEngine;

[CreateAssetMenu(fileName = "IncomeBuilding", menuName = "Building Types/Income Building")]
public class IncomeBuilding : BuildingLevel
{
    [Space, Header("Income Building Info")]
    [SerializeField] private Resources resourcesToRun;
    [SerializeField] private int resourceCount;
    [SerializeField] private float moralOutputPercentage;

    public override void Execute()
    {
        Debug.Log("Method colled 1");
    }

    public override void LevelUp(Building building)
    {
        building.ChangeBuilding(buildingNextLevel);
    }
}
