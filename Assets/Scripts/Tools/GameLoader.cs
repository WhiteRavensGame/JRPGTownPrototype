using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : AsyncLoader
{
    [SerializeField] private GameObject _gameManager = null;
    [SerializeField] private int sceneIndexToLoad = 1;
    private static int _sceneIndex = 1;
    private static GameLoader _instance; // The only singleton you should have.

    [SerializeField] private List<Component> _moduleComponents = new List<Component>();

    public static Transform SystemsParent { get { return _systemsParent; } }
    private static Transform _systemsParent;

    protected override void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        Debug.Log("GameLoader Starting");

        // Saftey check
        if (_instance != null && _instance != this)
        {
            Debug.Log("A duplicate instance of the GameLoader was found, and will be ignored. Only one instance is permitted");
            Destroy(gameObject);
            return;
        }

        // Set reference to this instance
        _instance = this;

        // Make persistent
        DontDestroyOnLoad(gameObject);

        // Scene Index Check
        if (sceneIndexToLoad == 0)
        {
            // We don't want to load the next scene, stay on this one.
            _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
        else if (sceneIndexToLoad < 0 || sceneIndexToLoad >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log($"Invalid Scene Index {sceneIndexToLoad} ... using default value of {_sceneIndex}");
        }
        else
        {
            _sceneIndex = sceneIndexToLoad;
        }

        // Setup System GameObject
        GameObject systemsGO = new GameObject("[Systems]");
        _systemsParent = systemsGO.transform;
        DontDestroyOnLoad(systemsGO);

        // Queue up loading routines
        Enqueue(IntializeCoreSystems(), 1);
        Enqueue(InitializeModularSystems(), 2);

        // Register the GameLoader
        ServiceLocator.Register<GameLoader>(this);

        // Set completion callback
        CallOnComplete(OnComplete);
    }

    private IEnumerator IntializeCoreSystems()
    {
        // Setup Core Systems
        Debug.Log("Loading Core Systems");

        var gm = Instantiate(_gameManager, SystemsParent);
        ServiceLocator.Register<SaveSystem>(gm.GetComponent<SaveSystem>());
        ServiceLocator.Register<GameManager>(gm.GetComponent<GameManager>());
        ServiceLocator.Register<VillageManager>(gm.GetComponent<VillageManager>());
        ServiceLocator.Register<ResourceManager>(gm.GetComponent<ResourceManager>());
        ServiceLocator.Register<EarningsManager>(gm.GetComponent<EarningsManager>());
        ServiceLocator.Register<PlayerManager>(gm.GetComponent<PlayerManager>());
        ServiceLocator.Register<EventManager>(gm.GetComponent<EventManager>());
        ServiceLocator.Register<ReputationManager>(gm.GetComponent<ReputationManager>());
        ServiceLocator.Register<SoundManager>(gm.GetComponent<SoundManager>());


        yield return null;
    }

    private IEnumerator InitializeModularSystems()
    {
        // Setup Additional Systems as needed
        Debug.Log("Loading Modular Systems");

        foreach (var comp in _moduleComponents)
        {
            if (comp is IGameModule)
            {
                var module = comp as IGameModule;
                yield return module.LoadModule();
            }
        }

        yield return null;
    }

    private void OnComplete()
    {
        Debug.Log("GameLoader Completed");
        StartCoroutine(LoadInitialScene(_sceneIndex));
    }

    private IEnumerator LoadInitialScene(int index)
    {
        Debug.Log("GameLoader Starting Scene Load");
        yield return SceneManager.LoadSceneAsync(index);
    }

    public void UnregisterAll()
    {
        if (!ServiceLocator.Get<GameManager>().LoadGame)
        {
            Destroy(ServiceLocator.Get<GodModifier>().gameObject);
        }

        ServiceLocator.Unregister<SaveSystem>();
        ServiceLocator.Unregister<VillageManager>();
        ServiceLocator.Unregister<ResourceManager>();
        ServiceLocator.Unregister<EarningsManager>();
        ServiceLocator.Unregister<PlayerManager>();
        ServiceLocator.Unregister<EventManager>();
        ServiceLocator.Unregister<ReputationManager>();
        ServiceLocator.Unregister<MainDialogue>();
        ServiceLocator.Unregister<TimeManager>();
        ServiceLocator.Unregister<PrefabManager>();
        ServiceLocator.Unregister<SaveManager>();
        ServiceLocator.Unregister<VillageInitialization>();
        ServiceLocator.Unregister<EndOfWeekPanel>();

        Destroy(_systemsParent.gameObject);

        ServiceLocator.Unregister<GameManager>();

        ServiceLocator.Unregister<GodModifier>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Initialize();
        _instance = null;
    }
}