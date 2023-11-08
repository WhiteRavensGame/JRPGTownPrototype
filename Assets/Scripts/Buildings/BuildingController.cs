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
        //if (ServiceLocator.Get<PlayerManager>().gameState == GameStates.MainScreen)
        //{
        //    ServiceLocator.Get<PlayerManager>().gameState = GameStates.PanelInfo;
        //}
            building.ActivatePanel(true);
    }

    public void OnClosePanel()
    {
        building.ActivatePanel(false);
        //ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
    }

    public void ExecuteBuildingLevel()
    {
        building.LevelUp();
    }
}
