using UnityEngine;

public abstract class BuildingLevel: ScriptableObject
{
    [SerializeField]
    private Resources resources;
    [SerializeField, TextArea(3, 10)]
    private string panelText;
    [SerializeField]
    private string buttonText;

    public string getPanelText { get { return panelText; } }
    public string getButtonText { get { return buttonText; } }

    public abstract void Execute();
}
