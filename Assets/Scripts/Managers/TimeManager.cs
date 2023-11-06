using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float dailyTime;
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private List<BuildingLevel> buildings;

    private EarningsManager earningsManager;

    private float timePlaying;
    private TimeSpan elapsTime;

    private int daysPassed = 0;
    private int weeksPassed = 0;

    private void Awake()
    {
        earningsManager = ServiceLocator.Get<EarningsManager>();

        elapsTime = TimeSpan.FromMinutes(dailyTime);
        timePlaying = dailyTime;
        textTimer.text = elapsTime.ToString("mm':'ss'.'ff");
    }

    private void Update()
    {
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
