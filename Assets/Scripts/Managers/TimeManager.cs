using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float dailyTime;
    [SerializeField] private TextMeshProUGUI textWeek;
    [SerializeField] private List<BuildingLevel> buildings;

    [SerializeField] private GameObject _resourceManagementObj;
    [SerializeField] private GameObject _mainCanvas;

    private EarningsManager _earningsManager;
    private ResourceManager _resourceManager;
    private PlayerManager _playerManager;

    private float timePlaying;
    private TimeSpan elapsTime;

    private int daysPassed = 0;
    private int weeksPassed = 0;
    private bool initialize = false;

    public void Initialize()
    {
        _earningsManager = ServiceLocator.Get<EarningsManager>();
        _resourceManager = ServiceLocator.Get<ResourceManager>();
        _playerManager = ServiceLocator.Get<PlayerManager>();
        ServiceLocator.Get<EventManager>().endOfDay.AddListener(ResetDay);

        elapsTime = TimeSpan.FromMinutes(dailyTime);

        Load();

        textWeek.text = "Week " + weeksPassed;

        initialize = true;
    }

    private void Update()
    {
        if (!initialize || _playerManager.gameState == GameStates.EndOfWeek ||
            _playerManager.gameState == GameStates.Talking)
        {
            return;
        }

        if (timePlaying <= 0.0f)
        {
            ResetDay();
        }

        timePlaying -= Time.deltaTime / 60;
        elapsTime = TimeSpan.FromMinutes(timePlaying);

    }

    public void ResetDay()
    {
        if (_playerManager.gameState != GameStates.MainScreen)
        {
            return;
        }

        ++daysPassed;

        if (daysPassed >= 5)
        {
            EndOfWeek();
            ServiceLocator.Get<SaveManager>().SaveData();
        }

        timePlaying = dailyTime;
        _earningsManager.CalculateEarnings();
        _resourceManager.UpdateResourceText();
        elapsTime = TimeSpan.FromMinutes(timePlaying);
    }

    private void EndOfWeek()
    {
        if (weeksPassed > 0)
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

        if (weeksPassed > 5)
        {
            SceneManager.LoadScene("RoundTable");
        }

        daysPassed = 0;
        ++weeksPassed;
        _mainCanvas.SetActive(false);
        _resourceManagementObj.SetActive(true);
        _playerManager.gameState = GameStates.EndOfWeek;
        textWeek.text = "Week " + weeksPassed;
    }

    public bool IsWeekOne()
    {
        if (weeksPassed == 1)
        {
            return true;
        }

        return false;
    }

    public int GetWeek()
    {
        return weeksPassed;
    }

    public void Load()
    {
        var newData = ServiceLocator.Get<SaveSystem>().Load<SaveTime>("TMsave.doNotOpen");
        if (ServiceLocator.Get<GameManager>().LoadGame && !EqualityComparer<SaveTime>.Default.Equals(newData, default))
        {
            elapsTime = TimeSpan.FromMinutes(dailyTime);
            timePlaying = newData.timePlaying;
            daysPassed = newData.daysPassed;
            weeksPassed = newData.weeksPassed;
            _mainCanvas.SetActive(false);
            _resourceManagementObj.SetActive(true);
        }
        else
        {
            timePlaying = dailyTime;
            EndOfWeek();
        }
    }

    [ContextMenu("TestSave")]
    public void Save()
    {
        SaveTime saveTime = new SaveTime();
        saveTime.timePlaying = timePlaying;
        saveTime.daysPassed = daysPassed;
        saveTime.weeksPassed = weeksPassed;
        ServiceLocator.Get<SaveSystem>().Save<SaveTime>(saveTime, "TMsave.doNotOpen");
    }

    [System.Serializable]
    private class SaveTime
    {
        public float timePlaying;
        public int daysPassed;
        public int weeksPassed;
    }
}
