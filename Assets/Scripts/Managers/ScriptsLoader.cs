using UnityEngine;

public class ScriptsLoader : MonoBehaviour
{
    private GameLoader loader;

    [SerializeField] TimeManager _timeManager;
    [SerializeField] PrefabManager _prefabManager;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        ServiceLocator.Register<TimeManager>(_timeManager);
        ServiceLocator.Register<PrefabManager>(_prefabManager);

        _timeManager.Initialize();
    }
}
