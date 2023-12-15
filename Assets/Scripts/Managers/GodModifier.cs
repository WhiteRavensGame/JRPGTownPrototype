using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GodModification
{
    MoraleBoost,
    TroopBoost,
    SilkBoost,
    FoodBoost,
    MineBoost,
    PopulationSafety,
    DoubleProduction
}

public class GodModifier : MonoBehaviour
{
    private ResourceManager _rm;

    public GodModification Modification { get; private set; }
    public bool ResourceGod { get; private set; } = false;

    private void Awake()
    {
        ServiceLocator.Register<GodModifier>(this);
        if(ServiceLocator.Get<GameManager>().LoadGame)
        {
            DontDestroyOnLoad(this);
            ServiceLocator.Get<EarningsManager>().InitializeGod(this);
            _rm = ServiceLocator.Get<ResourceManager>();
            Load();
            SceneManager.LoadScene("MainScene");
        }
    }

    public void ChooseGod(int modification)
    {
        DontDestroyOnLoad(this);
        ServiceLocator.Get<EarningsManager>().InitializeGod(this);
        _rm = ServiceLocator.Get<ResourceManager>();

        Modification = (GodModification)modification;

        switch(Modification)
        {
            case GodModification.MoraleBoost:
                _rm.AddResource(Resources.Moral, 10);
                break;
            case GodModification.TroopBoost:
                _rm.AddResource(Resources.Troops, 10);
                break;
            case GodModification.SilkBoost:
                ResourceGod = true;
                break;
            case GodModification.FoodBoost:
                ResourceGod = true;
                break;
            case GodModification.MineBoost:
                ResourceGod = true;
                break;
            default: break;
        }

        Save();
        SceneManager.LoadScene("MainScene");
    }

    public void AddResource()
    {
        switch (Modification)
        {
            case GodModification.SilkBoost:
                _rm.AddResource(Resources.Silk, 3);
                break;
            case GodModification.FoodBoost:
                _rm.AddResource(Resources.Fish, 3);
                break;
            case GodModification.MineBoost:
                _rm.AddResource(Resources.Iron, 3);
                break;
        }
    }

    private void Save()
    {
        GodSave saveGod = new GodSave();
        saveGod.Modification = Modification;
        saveGod.ResourceGod = ResourceGod;
        ServiceLocator.Get<SaveSystem>().Save<GodSave>(saveGod, "Godsave.doNotOpen");
    }

    private void Load()
    {
        var newData = ServiceLocator.Get<SaveSystem>().Load<GodSave>("Godsave.doNotOpen");
        if (ServiceLocator.Get<GameManager>().LoadGame && !EqualityComparer<GodSave>.Default.Equals(newData, default))
        {
            Modification = newData.Modification;
            ResourceGod = newData.ResourceGod;
            Time.timeScale = 1.0f;
        }
    }

    [System.Serializable]
    private struct GodSave
    {
        public GodModification Modification;
        public bool ResourceGod;
    }

    public void DeleteGod()
    {
        Destroy(this.gameObject);
    }
}
