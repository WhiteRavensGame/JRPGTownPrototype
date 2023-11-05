using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private Building building;

    private void Awake()
    {
        building = GetComponent<Building>();
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
