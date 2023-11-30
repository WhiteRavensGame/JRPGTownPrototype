using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerManager playerManager;

    [SerializeField] private Button _eventButton;

    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _silkText;
    [SerializeField] private TextMeshProUGUI _moralText;

    [SerializeField] private GameObject _upgradeScreen;
    [SerializeField] private GameObject _characterScreen;
    [SerializeField] private GameObject _upgradeButton;
    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private TextMeshProUGUI _villagerCount;

    private void Awake()
    {
        playerManager = ServiceLocator.Get<PlayerManager>();
        ServiceLocator.Get<EventManager>().SetUpButton(_eventButton);
    }

    public void UpdateResourceText(int gold, int fish, int iron, int silk, float morale)
    {
        _goldText.text = gold.ToString();
        _ironText.text = iron.ToString();
        _silkText.text = silk.ToString();
        _fishText.text = fish.ToString();
        _moralText.text = morale.ToString() + "%";
    }

    public void UpdateVillagerCount(int left, int total)
    {
        _villagerCount.text = left.ToString() + "/" + total.ToString();
    }

    public void PauseGame()
    {
        if (playerManager.gameState == GameStates.Paused || playerManager.gameState == GameStates.MainScreen)
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            _pauseScreen.SetActive(true);

            if (playerManager.gameState == GameStates.MainScreen)
            {
                playerManager.gameState = GameStates.Paused;
            }
            else
            {
                playerManager.gameState = GameStates.MainScreen;
                _pauseScreen.SetActive(false);
            }
        }
    }

    public void ActivateUpgradeScreen()
    {
        if (ServiceLocator.Get<PlayerManager>().gameState == GameStates.MainScreen)
        {
            Debug.Log("opening upgrade screen");
            ServiceLocator.Get<PlayerManager>().gameState = GameStates.PanelInfo;
            _upgradeScreen.SetActive(true);
            _upgradeButton.SetActive(false);
        }
    }

    public void DeactivateUpgradeScreen()
    {
        Debug.Log("closing upgrade screen");
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        _upgradeScreen.SetActive(false);
        _upgradeButton.SetActive(true);
    }

    public void ActivateCharacterScreen()
    {
        if (ServiceLocator.Get<PlayerManager>().gameState == GameStates.MainScreen)
        {
            Debug.Log("opening character screen");
            ServiceLocator.Get<PlayerManager>().gameState = GameStates.PanelInfo;
            _characterScreen.SetActive(true);
        }
    }

    public void DeactivateCharacterScreen()
    {
        Debug.Log("closing character screen");
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        _characterScreen.SetActive(false);
    }
}
