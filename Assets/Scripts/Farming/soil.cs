using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil : MonoBehaviour
{
    public bool plantable = false;
    public bool planted = false;

    public int monthPlanted = 0;

    public float moisture = 10.0f;
    private float moistureMod = 1.0f;
    public int lastDay = 0;
    public int currentDay = 0;

    public float yield = 0.0f;
    public float yieldFactor =0;

    public float growthFactor = 0.01f;

    private GameObject timer;

   // PlayerData data = null;

    void updateMoisture()
    {
        float random;
        random = Random.Range(0.0f, 0.4f);
        moisture -= random;
    }

    void upMoistureMod()
    {

        //moistureMod = 
    }

    void updateGrowth()
    {
        if (monthPlanted == 3)
            growthFactor += .01f;
    }

    void updateYield()
    {
        if (yield < 100.0f && planted)
        {
            yield += .1f;

            if (yield > (yieldFactor + 5.0f))
            {
                //   Debug.Log("yield updated");
                yieldFactor = Mathf.Round(yield);
                SaveSystem.SavePlayer(null, this, null);
            }
        }
    }

    public void plantPot()
    {
        planted = true;
        monthPlanted = timer.GetComponent<timeTracking>().getCurrentTime().monthNum;
        yieldFactor = 0;
        updateGrowth();
        SaveSystem.SavePlayer(null, this, null);
    }

    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        lastDay = data.day;

        currentDay = lastDay;

        monthPlanted = data.monthPlanted;

        planted = data.planted;

        yield = data.currentYield;

        yieldFactor = Mathf.Round(yield);

        timer = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        currentDay = timer.GetComponent<timeTracking>().getCurrentTime().day;

        if (currentDay != lastDay)
        {
            lastDay = currentDay;

            updateMoisture();

            updateYield();

           // Debug.Log("day");
        }

        if (plantable)
            planted = false;


    }
}
