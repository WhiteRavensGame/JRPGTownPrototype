using UnityEngine;

public enum GameStates
{
    MainScreen,
    PanelInfo,
    EndOfDay
}

public class PlayerManager : MonoBehaviour
{
    public GameStates gameState;
}
