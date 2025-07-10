using TMPro;
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
    [SerializeField] TextMeshProUGUI timeText;

    void Update()
    {
        currentTimeBetweenTricks += Time.deltaTime;
        UpdateTimeText();
        if (currentTimeBetweenTricks >= timeBetweenTicks)
        {
            TickPeriod();
        }
    }
    void UpdateTimeText()
    {
        timeText.text = GetTimeString();
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
        return $"Day: {day}, Weekday: {weekday}, Time: {timePeriod}";
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
