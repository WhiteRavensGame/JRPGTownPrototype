using UnityEngine;

public class BuildingController : MonoBehaviour
{
    GameLoader _loader = null;
    PlayerManager _playerManager = null;

    [SerializeField] private Building building;

    private void Awake()
    {
        _loader = ServiceLocator.Get<GameLoader>();
        _loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        _playerManager = ServiceLocator.Get<PlayerManager>();
    }

    public void OnClosePanel()
    {
        building.ActivatePanel(false);
        _playerManager.gameState = GameStates.MainScreen;
    }

    public void ExecuteBuildingLevel()
    {
        building.LevelUp();
        ServiceLocator.Get<ResourceManager>().UpdateResourceText();
    }

    private void OnMouseDown()
    {
        if (_playerManager.gameState == GameStates.MainScreen)
        {
            _playerManager.gameState = GameStates.PanelInfo;
            building.ActivatePanel(true);
        }
    }
}
