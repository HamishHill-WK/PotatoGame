using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public int year = 0;
    public int day = 0;
    public int hour = 0;
    public int minute = 0;
    private int second = 0;
    private int mSecond = 0;
    public int speedFactor = 1;

    public int months = 0;

    enum month { January = 0, February, March, April, May, June, July, August, September, October, November, December };
    month currentMonth = month.January;

    void Update()
    {
        second += speedFactor;
        months = ((int)currentMonth);

        if(mSecond >= 60)
        {
            second++;
            mSecond = 0;
        }  
        
        if(second == 60)
        {
            minute++;
            second = 0;
        }

        if(minute == 60)
        {
            hour++;
            minute = 0;
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
                //months = currentMonth;
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
                    if (currentMonth == month.January || currentMonth == month.March || currentMonth == month.May || currentMonth == month.July 
                        || currentMonth == month.August || currentMonth == month.October || currentMonth == month.December)
                    {
                        //months++;
                        currentMonth++;
                        day = 0;
                    }
                }
            }
        }
    }
}
