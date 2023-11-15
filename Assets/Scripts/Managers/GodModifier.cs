using UnityEngine;

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

    public static GodModification Modification { get; private set; }
    public bool ResourceGod { get; private set; } = false;

    public void ChooseGod(GodModification modification)
    {
        DontDestroyOnLoad(this);
        ServiceLocator.Get<EarningsManager>().InitializeGod(this);
        _rm = ServiceLocator.Get<ResourceManager>();

        Modification = modification;

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
}
