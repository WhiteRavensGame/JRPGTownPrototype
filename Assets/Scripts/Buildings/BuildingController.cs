using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private Building building;
    private int levelNum = -1;

    private void Awake()
    {
        building = GetComponent<Building>();
    }

    private void OnMouseDown()
    {
        building.ChangeInfoString(levelNum);
        building.ActivatePanel(true);
    }

    public void OnClosePanel()
    {
        building.ActivatePanel(false);
    }

    public void ExecuteBuildingLevel()
    {
        building.Execute();
    }
}
