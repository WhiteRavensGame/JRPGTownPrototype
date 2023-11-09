using UnityEngine;

public enum GodModification
{
    MoraleBoost,
    SilkBoost,
    FoodBoost,
    DefenseBoost,
    PopulationSafety,
    DoubleProduction
}

public class GodModifier : MonoBehaviour
{
    public GodModification Modification { get; private set; }

    public void ChooseGod(GodModification modification)
    {
        Modification = modification;
    }
}
