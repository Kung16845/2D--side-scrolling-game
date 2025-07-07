using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private int day;
    [SerializeField] private TimePeriod timePeriod;
    [SerializeField] private Weekday weekday;
    public int Day => day;
    public TimePeriod TimePeriod => timePeriod;
    public Weekday Weekday => weekday;
    [SerializeField] private float timeBetweenTicks = 60f;
    [SerializeField] private float currentTimeBetweenTricks = 0;

    // Update is called once per frame
    void Update()
    {
        currentTimeBetweenTricks += Time.deltaTime;
        if (currentTimeBetweenTricks >= timeBetweenTicks)
        {
            TickPeriod();
        }
    }
    public void TickPeriod()
    {
        currentTimeBetweenTricks = 0;
        switch (timePeriod)
        {
            case TimePeriod.Morning:
                timePeriod = TimePeriod.Afternoon;
                break;
            case TimePeriod.Afternoon:
                timePeriod = TimePeriod.Evening;
                break;
            case TimePeriod.Evening:
                timePeriod = TimePeriod.Morning;
                weekday = (Weekday)(((int)weekday + 1) % 7);
                day++;
                break;
        }
    }
    [ContextMenu("GetTimeString")]
    public string GetTimeString()
    {   
        Debug.Log($"Day : {day} {weekday} {timePeriod}");
        return $"Day : {day} {weekday} {timePeriod}";
    }
}
public enum TimePeriod
{
    Morning,
    Afternoon,
    Evening,
}
public enum Weekday
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}
