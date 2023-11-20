using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float dailyTime;
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private List<BuildingLevel> buildings;
    [SerializeField] private Slider weeklySlider;

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

        var newData = ServiceLocator.Get<SaveSystem>().Load<SaveTime>("TMsave.doNotOpen");
        if (!EqualityComparer<SaveTime>.Default.Equals(newData, default))
        {
            timePlaying = newData.timePlaying;
            daysPassed = newData.daysPassed;
            weeksPassed = newData.weeksPassed;
        }
        else
        {
            timePlaying = dailyTime;
            EndOfWeek();
        }

        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");

        initialize = true;
    }

    private void Update()
    {
        if (!initialize || _playerManager.gameState == GameStates.EndOfWeek)
        {
            return;
        }

        if (timePlaying <= 0.0f)
        {
            ServiceLocator.Get<EventManager>().endOfDay.Invoke();
        }

        timePlaying -= Time.deltaTime / 60;
        elapsTime = TimeSpan.FromMinutes(timePlaying);
        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");
        weeklySlider.value = timePlaying / dailyTime;

    }

    public void ResetDay()
    {
        if (_playerManager.gameState != GameStates.MainScreen)
        {
            return;
        }

        if (daysPassed >= 5)
        {
            EndOfWeek();
        }

        ++daysPassed;
        timePlaying = dailyTime;
        _earningsManager.CalculateEarnings();
        _resourceManager.UpdateResourceText();
        elapsTime = TimeSpan.FromMinutes(timePlaying);
        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");
    }

    private void EndOfWeek()
    {
        if (weeksPassed > 0)
        {
            float villagers = 6 * _resourceManager.GetResourceAmt(Resources.Moral) / 100 - 3;

            ServiceLocator.Get<VillageManager>().EndDayAllocationStart((int)villagers);
        }

        daysPassed = 0;
        ++weeksPassed;
        _mainCanvas.SetActive(false);
        _resourceManagementObj.SetActive(true);
        _playerManager.gameState = GameStates.EndOfWeek;
    }

    public bool IsWeekOne()
    {
        if (weeksPassed == 1)
        {
            return true;
        }

        return false;
    }

    private void OnDestroy()
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
