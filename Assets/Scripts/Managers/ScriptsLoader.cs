using UnityEngine;

public class ScriptsLoader : MonoBehaviour
{
    private GameLoader loader;

    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private PrefabManager _prefabManager;
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private VillageInitialization _villageInit;
    [SerializeField] private MainDialogue _mainDialogue;
    [SerializeField] private EndOfWeekPanel _endOfWeekPanel;
 
    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }
    
    private void Initialize()
    {
        ServiceLocator.Register<MainDialogue>(_mainDialogue);
        ServiceLocator.Register<TimeManager>(_timeManager);
        ServiceLocator.Register<PrefabManager>(_prefabManager);
        ServiceLocator.Register<SaveManager>(_saveManager);
        ServiceLocator.Register<VillageInitialization>(_villageInit);
        ServiceLocator.Register<EndOfWeekPanel>(_endOfWeekPanel);

        _timeManager.Initialize();
        _saveManager.Initialize();
        _villageInit.Initialize();
        _endOfWeekPanel.Initialize();

        ServiceLocator.Get<EventManager>().Initialize();
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<MainDialogue>();
        ServiceLocator.Unregister<TimeManager>();
        ServiceLocator.Unregister<PrefabManager>();
        ServiceLocator.Unregister<SaveManager>();
        ServiceLocator.Unregister<VillageInitialization>();
        ServiceLocator.Unregister<EndOfWeekPanel>();
    }
}
