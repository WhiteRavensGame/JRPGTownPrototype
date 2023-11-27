using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _silkText;

    [SerializeField] private TextMeshProUGUI _villagerCount;

    private void Awake()
    {
        playerManager = ServiceLocator.Get<PlayerManager>();
    }

    public void UpdateResourceText(int gold, int fish, int iron, int silk)
    {
        _goldText.text = gold.ToString();
        _ironText.text = iron.ToString();
        _silkText.text = silk.ToString();
        _fishText.text = fish.ToString();
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
}
