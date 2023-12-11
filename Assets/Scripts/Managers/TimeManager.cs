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

        Load();

        textWeek.text = "Week " + _week;
        textDays.text = "Day " + _day;

        initialize = true;
    }

    public void EndDay()
    {
        if (_playerManager.gameState != GameStates.MainScreen)
        {
            return;
        }

        ++_day;

        if (_day > 5)
        {
            EndOfWeek();
            ServiceLocator.Get<SaveManager>().SaveData();
        }

        _earningsManager.CalculateEarnings();
        _resourceManager.UpdateResourceText();
        textDays.text = "Day " + _day;
        ServiceLocator.Get<EventManager>().CheckEvent();
        ServiceLocator.Get<ResourceManager>().CheckLoanStatus();
    }

    private void EndOfWeek()
    {
        ++_week;
        if (_week > 0)
        {
            float morale = _resourceManager.GetResourceAmt(Resources.Moral);
            int amount = 0;

            if (morale < 11)
            {
                amount = -3;
            }
            else if (morale < 25)
            {
                amount = -1;
            }
            else if (morale < 41)
            {
                amount = 0;
            }
            else if (morale < 61)
            {
                amount = 1;
            }
            else if (morale < 76)
            {
                amount = 2;
            }
            else if (morale < 91)
            {
                amount = 3;
            }
            else if (morale <= 100)
            {
                amount = 5;
            }

            ServiceLocator.Get<VillageManager>().EndDayAllocationStart((int)amount);
        }

        if (_week >= 5)
        {
            ServiceLocator.Get<GameManager>().SaveVariables();
            SceneManager.LoadScene("RoundTable");
        }

        float villagers = 6 * _resourceManager.GetResourceAmt(Resources.Moral) / 100 - 3;
        ServiceLocator.Get<VillageManager>().EndDayAllocationStart((int)villagers);

        _day = 1;
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
