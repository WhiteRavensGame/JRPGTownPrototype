using TMPro;
using UnityEngine;

public class EndOfDayHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI extraVillagersAmt;
    private VillageManager vManager;
    private GameLoader loader;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        vManager = ServiceLocator.Get<VillageManager>();
    }
}
