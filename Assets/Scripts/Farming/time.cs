using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script was written by Hamish Hill github: @HamishHill-wk

public class time : MonoBehaviour
{
    public int year = 0;
    public int monthNum = 0;
    public int day = 0;
    public int hour = 0;
    public int minute = 0;
    private int second = 0;
   // private int mSecond = 0;
    public int speedFactor = 1;

    enum month { January = 0, February, March, April, May, June, July, August, September, October, November, December };
    month currentMonth = month.January;

    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        year = data.currentYear;
        currentMonth = (month)data.currentMonth;
        day = data.day;
        hour = data.hour;
    }

    void Update()
    {
        minute += speedFactor;
        monthNum = ((int)currentMonth);

        if(minute == 60)
        {
            hour++;
            minute = 0;

            SaveSystem.SavePlayer(null, null, this);
        }

        if(hour == 24)
        {
            day++;
            hour = 0;
        }

        
        if (currentMonth == month.February)
        {
            if (day >= 28)
            {
                currentMonth++;
                day = 0;
            }
        }

        if (currentMonth != month.February)
        {
            if (day >= 30)
            {
                if (currentMonth == month.April || currentMonth == month.June || currentMonth == month.September || currentMonth == month.November)
                {
                   // months++;
                    currentMonth++;
                    day = 0;
                }

                if (day == 31)
                {
                    if( currentMonth == month.December)
                    {
                        currentMonth = month.January;
                        year++;
                    }

                    if (currentMonth == month.January || currentMonth == month.March || currentMonth == month.May || currentMonth == month.July 
                        || currentMonth == month.August || currentMonth == month.October )
                    {
                        currentMonth++;
                        day = 0;
                    }
                }
            }
        }
    }
}
