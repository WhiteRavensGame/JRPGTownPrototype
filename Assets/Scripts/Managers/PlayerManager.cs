using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameStates gameState;
    public bool InTutorial { get; set; } = false;
    public bool AllocatingVillagers { get; set; } = false;   
}
