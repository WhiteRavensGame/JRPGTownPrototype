using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncomeBuilding", menuName = "Building Types/Income Building")]
public class IncomeBuilding : BuildingLevel
{
    [Space, Header("Income Building Info")]
    [SerializeField] private Resources resourcesToRun;
    [SerializeField] private int resourceCount;
    [SerializeField] private float moralOutputPercentage;

    private void Awake()
    {
        rm = ServiceLocator.Get<ResourceManager>();
        vm = ServiceLocator.Get<VillageManager>();
    }

    public override void Execute()
    {
        Debug.Log("Method colled 1");
    }

    public override void LevelUp(Building building)
    {
        building.ChangeBuilding(buildingNextLevel);
    }

    public override KeyValuePair<Resources, int> CalculateDayEarning(Building building)
    {
        bool canUseResources = false;
        int villagers = vm.GetAllocatedVillagers(building.GetBuildingType());
        float percentOfTotal = 0.0f;

        while (!canUseResources && villagers > 0)
        {
            percentOfTotal = villagers / getMaxVillagers;

            int resourcesRecquired = (int)((float)resourceCount * percentOfTotal);

            if (rm.GetResourceAmt(resourcesToRun) > resourcesRecquired)
            {
                canUseResources = true;
                rm.UseResources(resourcesToRun, resourcesRecquired);
            }
            else
            {
                villagers--;
                percentOfTotal = 0.0f;
            }
        }

        int income = getIncome;

        income = (int)((float)income * percentOfTotal);

        return new KeyValuePair<Resources, int>(Resources.Gold, income); // add resources to resource manager
    }
}
