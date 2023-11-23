using UnityEngine;

public class ScriptsLoader : MonoBehaviour
{
    private GameLoader loader;

    [SerializeField] TimeManager _timeManager;
    [SerializeField] PrefabManager _prefabManager;
    [SerializeField] SaveManager _saveManager;

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

        _timeManager.Initialize();
        _saveManager.Initialize();
    }
}
