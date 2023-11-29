using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private List<Building> _buildings;
    private TimeManager _timeManager;
    private ResourceManager _resourceManager;

    public void Initialize()
    {
        _timeManager = ServiceLocator.Get<TimeManager>();
        _resourceManager = ServiceLocator.Get<ResourceManager>();
    }

    public void SaveData()
    {
        _timeManager.Save();
        _resourceManager.Save();

        foreach(var building in _buildings)
        {
            building.Save();
        }
    }
}
