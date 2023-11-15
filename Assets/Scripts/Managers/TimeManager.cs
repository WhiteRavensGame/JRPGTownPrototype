using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private GameLoader loader;
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

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        _earningsManager = ServiceLocator.Get<EarningsManager>();
        _resourceManager = ServiceLocator.Get<ResourceManager>();
        _playerManager = ServiceLocator.Get<PlayerManager>();
        ServiceLocator.Get<EventManager>().endOfDay.AddListener(ResetDay);

        elapsTime = TimeSpan.FromMinutes(dailyTime);
        timePlaying = dailyTime;
        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");

        initialize = true;
        EndOfWeek();
    }

    private void Update()
    {
        if (!initialize || _playerManager.gameState == GameStates.EndOfWeek)
        {
            return;
        }

        timePlaying -= Time.deltaTime / 60;
        elapsTime = TimeSpan.FromMinutes(timePlaying);
        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");

        if (timePlaying <= 0.0f)
        {
            ServiceLocator.Get<EventManager>().endOfDay.Invoke();
        }
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
        int villagersNum = 6 * _resourceManager.GetResourceAmt(Resources.Moral) / 100 - 3;
        ServiceLocator.Get<VillageManager>().EndDayAllocationStart(villagersNum);

        daysPassed = 0;
        ++weeksPassed;
        weeklySlider.value = weeklySlider.maxValue - weeksPassed;
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
}
