using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textWeek;
    [SerializeField] private TextMeshProUGUI textDays;
    [SerializeField] private List<BuildingLevel> buildings;

    private EarningsManager _earningsManager;
    private ResourceManager _resourceManager;
    private PlayerManager _playerManager;

    private int _day = 0;
    private int _week = 0;
    private bool initialize = false;

    public void Initialize()
    {
        _earningsManager = ServiceLocator.Get<EarningsManager>();
        _resourceManager = ServiceLocator.Get<ResourceManager>();
        _playerManager = ServiceLocator.Get<PlayerManager>();
        ServiceLocator.Get<EventManager>().endOfDay.AddListener(ResetDay);

        Load();

        textWeek.text = "Week " + _week;
        textDays.text = "Day " + _day;

        initialize = true;
    }

    public void ResetDay()
    {
        if (_playerManager.gameState != GameStates.MainScreen)
        {
            return;
        }

        ++_day;

        if (_day >= 5)
        {
            EndOfWeek();
            ServiceLocator.Get<SaveManager>().SaveData();
        }

        _earningsManager.CalculateEarnings();
        _resourceManager.UpdateResourceText();
        textDays.text = "Day " + _day;
        ServiceLocator.Get<EventManager>().CheckEvent();
    }

    private void EndOfWeek()
    {
        if (_week > 0)
        {
            float villagers = 6 * _resourceManager.GetResourceAmt(Resources.Moral) / 100 - 3;

            ServiceLocator.Get<VillageManager>().EndDayAllocationStart((int)villagers);
        }

        if (_week > 5)
        {
            SceneManager.LoadScene("RoundTable");
        }

        _day = 0;
        ++_week;
        textWeek.text = "Week " + _week;
    }

    public bool IsWeekOne()
    {
        if (_week == 1)
        {
            return true;
        }

        return false;
    }

    public int GetWeek()
    {
        return _week;
    }

    public void Load()
    {
        var newData = ServiceLocator.Get<SaveSystem>().Load<SaveTime>("TMsave.doNotOpen");
        if (ServiceLocator.Get<GameManager>().LoadGame && !EqualityComparer<SaveTime>.Default.Equals(newData, default))
        {
            _day = newData.daysPassed;
            _week = newData.weeksPassed;
        }
        else
        {
            _day = 1;
            _week = 1;
        }
    }

    [ContextMenu("TestSave")]
    public void Save()
    {
        SaveTime saveTime = new SaveTime();
        saveTime.daysPassed = _day;
        saveTime.weeksPassed = _week;
        ServiceLocator.Get<SaveSystem>().Save<SaveTime>(saveTime, "TMsave.doNotOpen");
    }

    [System.Serializable]
    private class SaveTime
    {
        public int daysPassed;
        public int weeksPassed;
    }
}
