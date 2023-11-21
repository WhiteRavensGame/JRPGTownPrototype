using UnityEngine;

public class ScriptsLoader : MonoBehaviour
{
    private GameLoader loader;

    [SerializeField] TimeManager _timeManager;

    private Villager _villager;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        ServiceLocator.Register<TimeManager>(_timeManager);

        _timeManager.Initialize();
    }
}
