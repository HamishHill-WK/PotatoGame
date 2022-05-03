using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //Code Written by Blair McCartan

    public int[] totalPotatos = { 0, 0, 0, 0, 0, 0 };//hh
    public float currentYield;

    public int monthPlanted;        //hh

    public int currentYear; //hh
    public int currentMonth; //hh
    public int day;//hh
    public int hour;//hh

    public bool planted; //hh

    public PlayerData(int[] playerPotatos, soil playerSoil, timeTracking playerTime) //modified potato to be an array - hh 
    {
        if (playerPotatos != null)//hh
        {
           // totalPotatos.Clear();//hh
            int i = 0;//hh
            foreach (int p in playerPotatos)//hh
            {
                totalPotatos[i] = playerPotatos[i]; //hh
                i++;//hh
            }
        }

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