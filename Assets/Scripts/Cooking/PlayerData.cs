using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //Code Written by Blair McCartan

    public int totalPotatos;
    public float currentYield;

    public int monthPlanted;        //hh

    public int currentYear; //hh
    public int currentMonth; //hh
    public int day;//hh
    public int hour;//hh

    public bool planted; //hh

    public PlayerData(potato playerPotatos, soil playerSoil, timeTracking playerTime)
    {
        if(playerPotatos != null)//hh
        totalPotatos = playerPotatos.stock;

        if (playerSoil != null)//hh
        {
            monthPlanted = playerSoil.monthPlanted;//hh
            planted = playerSoil.planted;//hh
            currentYield = playerSoil.yield;//hh
        }

        if(playerTime !=null)
        { 
            currentYear = playerTime.getCurrentTime().year;//hh
            currentMonth = playerTime.getCurrentTime().monthNum;//hh
            day = playerTime.getCurrentTime().day;//hh
            hour = playerTime.getCurrentTime().hour;//hh
        }
    }

    //https://www.youtube.com/watch?v=XOjd_qU2Ido

    //End of code written by Blair McCartan
}
