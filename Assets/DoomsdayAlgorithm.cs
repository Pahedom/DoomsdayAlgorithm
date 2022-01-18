using UnityEngine;
using System;
using UnityEngine.UI;

public class DoomsdayAlgorithm : MonoBehaviour
{
    public int day;
    public int month;
    public int year;

    [HideInInspector] public bool leapYear;

    [HideInInspector] public string dayOfTheWeek;

    [SerializeField] private Text dayOfTheWeekText;

    bool ValidateDate()
    {
        if (year < 1)
        {
            return false;
        }

        leapYear = year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);

        if (month < 1 || month > 12)
        {
            return false;
        }

        int[] monthDays = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (day < 1 || day > monthDays[month - 1])
        {
            return false;
        }

        if (month == 2 && !leapYear)
        {
            if (day > 28)
            {
                return false;
            }
        }

        return true;
    }

    public void SetWeekDay()
    {
        if (!ValidateDate())
        {
            Debug.LogWarning("Invalid date");

            dayOfTheWeekText.text = "Invalid date!";

            return;
        }

        int century = year / 100;

        int[] centuryPattern = { 2, 0, 5, 3 };

        int doomsdayRef = centuryPattern[century % 4];

        int difference = year - century * 100;
        int doomsdayWeekDay = (doomsdayRef + difference + difference / 4) % 7;

        int[] monthDoomsdays = { 3, 28, 14, 4, 9, 6, 11, 8, 5, 10, 7, 12 };
        if (leapYear)
        {
            monthDoomsdays[0] = 4;
            monthDoomsdays[1] = 29;
        }

        int monthDoomsday = monthDoomsdays[month - 1];

        int weekDay;
        if (monthDoomsday > day)
        {
            weekDay = (doomsdayWeekDay + 7 - ((monthDoomsday - day) % 7)) % 7;
        }
        else
        {
            weekDay = (doomsdayWeekDay - monthDoomsday + day) % 7;
        }

        string[] weekDaysString = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        dayOfTheWeek = weekDaysString[weekDay];

        dayOfTheWeekText.text = dayOfTheWeek;
    }

    public void SetDay(string newValue)
    {
        try
        {
            day = Int32.Parse(newValue);
        }
        catch (FormatException)
        {
            return;
        }
    }

    public void SetMonth(string newValue)
    {
        try
        {
            month = Int32.Parse(newValue);
        }
        catch (FormatException)
        {
            return;
        }
    }

    public void SetYear(string newValue)
    {
        try
        {
            year = Int32.Parse(newValue);
        }
        catch (FormatException)
        {
            return;
        }
    }
}