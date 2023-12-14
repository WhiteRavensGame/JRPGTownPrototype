using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private PlayerManager playerManager;

    [SerializeField] private Button _eventButton;

    [SerializeField] private TextMeshProUGUI _upgradeGoldUIText;
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _silkText;
    [SerializeField] private TextMeshProUGUI _moralText;
    [SerializeField] private TextMeshProUGUI _troopsText;

    [SerializeField] private GameObject _upgradeScreen;
    [SerializeField] private GameObject _characterScreen;
    [SerializeField] private GameObject _assignCitizenPanel;
    [SerializeField] private GameObject _upgradeButton;
    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private TextMeshProUGUI _villagerCount;

    private void Awake()
    {
        playerManager = ServiceLocator.Get<PlayerManager>();
        ServiceLocator.Get<EventManager>().SetUpButton(_eventButton);
        _characterScreen.GetComponent<RectTransform>().localPosition = new Vector3(_characterScreen.transform.localPosition.x, -540.1105f, _characterScreen.transform.localPosition.z);
        _characterScreen.SetActive(false);
    }

    public void UpdateResourceText(int gold, int fish, int iron, int silk, float morale, int troops)
    {
        _upgradeGoldUIText.text = gold.ToString();
        _goldText.text = gold.ToString();
        _ironText.text = iron.ToString();
        _silkText.text = silk.ToString();
        _fishText.text = fish.ToString();
        _moralText.text = morale.ToString() + "%";
        _troopsText.text = troops.ToString();
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
                ServiceLocator.Get<SoundManager>().Play("PauseOpen");
                playerManager.gameState = GameStates.Paused;
            }
            else
            {
                ServiceLocator.Get<SoundManager>().Play("PauseClose");
                playerManager.gameState = GameStates.MainScreen;
                _pauseScreen.SetActive(false);
            }
        }
    }
    public void ActivateCitizenAssignmentScreen()
    {
        if (ServiceLocator.Get<PlayerManager>().gameState == GameStates.MainScreen)
        {
            ServiceLocator.Get<SoundManager>().Play("TopMainOpen");

            Debug.Log("opening citizen assignment screen");
            ServiceLocator.Get<PlayerManager>().gameState = GameStates.PanelInfo;
            _assignCitizenPanel.SetActive(true);
        }
    }
    public void DecativeCitizenAssignmentScreen()
    {
        ServiceLocator.Get<SoundManager>().Play("TopCloseOpen");

        Debug.Log("closing citizen assignment screen");
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        _assignCitizenPanel.SetActive(false);
    }

    public void ActivateUpgradeScreen()
    {
        if (playerManager.gameState == GameStates.MainScreen)
        {
            ServiceLocator.Get<SoundManager>().Play("TopMainOpen");

            Debug.Log("opening upgrade screen");
            playerManager.gameState = GameStates.PanelInfo;
            _upgradeScreen.SetActive(true);
            _upgradeButton.SetActive(false);
        }
    }

    public void DeactivateUpgradeScreen()
    {
        ServiceLocator.Get<SoundManager>().Play("TopCloseOpen");

        Debug.Log("closing upgrade screen");
        playerManager.gameState = GameStates.MainScreen;
        _upgradeScreen.SetActive(false);
        _upgradeButton.SetActive(true);
    }

    public void ActivateCharacterScreen()
    {
        if (playerManager.gameState == GameStates.MainScreen)
        {
            ServiceLocator.Get<SoundManager>().Play("TopMainOpen");

            Debug.Log("opening character screen");
            playerManager.gameState = GameStates.PanelInfo;
            _characterScreen.SetActive(true);
        }
    }

    public void DeactivateCharacterScreen()
    {
        ServiceLocator.Get<SoundManager>().Play("TopCloseOpen");

        Debug.Log("closing character screen");
        playerManager.gameState = GameStates.MainScreen;
        _characterScreen.SetActive(false);
    }
    public void ExitButton()
    {
        ServiceLocator.Get<SoundManager>().Play("TopCloseOpen");

        GameLoader loader = ServiceLocator.Get<GameLoader>();
        loader.UnregisterAll();
        loader.Restart();
    }
}
