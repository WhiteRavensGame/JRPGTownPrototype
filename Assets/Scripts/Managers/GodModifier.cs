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
    public GodModification Modification { get; private set; }
    public bool ResourceGod { get; private set; } = false;

    public void ChooseGod(GodModification modification)
    {
        DontDestroyOnLoad(this);
        ServiceLocator.Get<EarningsManager>().InitializeGod(this);

        Modification = modification;

        switch(Modification)
        {
            case GodModification.MoraleBoost:
                ServiceLocator.Get<ResourceManager>().AddResource(Resources.Moral, 10);
                break;
            case GodModification.TroopBoost:
                ServiceLocator.Get<ResourceManager>().AddResource(Resources.Troops, 10);
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
            case GodModification.PopulationSafety:
                break;
            case GodModification.DoubleProduction:
                break;
            default: break;
        }
    }
}
