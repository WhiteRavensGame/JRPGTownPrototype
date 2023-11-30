using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _silkText;
<<<<<<< Updated upstream
=======
    [SerializeField] private TextMeshProUGUI _moralText;
    [SerializeField] private TextMeshProUGUI _troopText;

>>>>>>> Stashed changes
    [SerializeField] private GameObject _upgradeScreen;
    [SerializeField] private GameObject _upgradeButton;

    [SerializeField] private TextMeshProUGUI _villagerCount;

    private void Awake()
    {
        playerManager = ServiceLocator.Get<PlayerManager>();
    }

<<<<<<< Updated upstream
    public void UpdateResourceText(int gold, int fish, int iron, int silk)
=======
    public void UpdateResourceText(int gold, int fish, int iron, int silk, float morale, int troops)
>>>>>>> Stashed changes
    {
        _goldText.text = gold.ToString();
        _ironText.text = iron.ToString();
        _silkText.text = silk.ToString();
        _fishText.text = fish.ToString();
<<<<<<< Updated upstream
=======
        _moralText.text = morale.ToString() + "%";
        _troopText.text = troops.ToString();
>>>>>>> Stashed changes
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

            if (playerManager.gameState == GameStates.MainScreen)
            {
                playerManager.gameState = GameStates.Paused;
            }
            else
            {
                playerManager.gameState = GameStates.MainScreen;
            }
        }
    }

    public void ActivateUpgradeScreen()
    {
        _upgradeScreen.SetActive(true);
        _upgradeButton.SetActive(false);
    }

    public void DeactivateUpgradeScreen()
    {
        _upgradeScreen.SetActive(false);
        _upgradeButton.SetActive(true);
    }
}
