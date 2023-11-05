using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private Building building;

    private void Awake()
    {
        building = GetComponent<Building>();
        vm = ServiceLocator.Get<VillageManager>();
    }

    private void OnMouseDown()
    {
        building.ActivatePanel(true);
    }

    public void OnClosePanel()
    {
        building.ActivatePanel(false);
    }

    public void ExecuteBuildingLevel()
    {
        building.LevelUp();
    }
}
