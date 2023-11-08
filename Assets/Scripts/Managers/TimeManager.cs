using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    GameLoader loader;
    [SerializeField] private float dailyTime;
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private List<BuildingLevel> buildings;

    private EarningsManager earningsManager;

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
        earningsManager = ServiceLocator.Get<EarningsManager>();

        elapsTime = TimeSpan.FromMinutes(dailyTime);
        timePlaying = dailyTime;
        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");

        initialize = true;
    }

    private void Update()
    {
        if (!initialize)
        {
            return;
        }

        timePlaying -= Time.deltaTime / 60;
        elapsTime = TimeSpan.FromMinutes(timePlaying);
        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");

        if(timePlaying <= 0.0f)
        {
            ResetDay();
        }
    }

    public void ResetDay()
    {
        ++daysPassed;
        timePlaying = dailyTime;
        earningsManager.CalculateEarnings();

        if (daysPassed >= 5)
        {
            daysPassed = 0;
            ++weeksPassed;
        }
    }
}
