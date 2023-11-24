using UnityEngine;

public class ScriptsLoader : MonoBehaviour
{
    private GameLoader loader;

    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private PrefabManager _prefabManager;
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private VillageInitialization _villageInit;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        ServiceLocator.Register<TimeManager>(_timeManager);
        ServiceLocator.Register<PrefabManager>(_prefabManager);
        ServiceLocator.Register<SaveManager>(_saveManager);
        ServiceLocator.Register<VillageInitialization>(_villageInit);

        _timeManager.Initialize();
        _saveManager.Initialize();
        _villageInit.Initialize();
    }
}
