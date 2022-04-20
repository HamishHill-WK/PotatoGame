using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil : MonoBehaviour
{
    public bool plantable = false;
    public bool planted = false;

    public int monthPlanted = 0;
    public float seasonMod = 0.0f;

    public float moisture = 100.0f;
    public float moistureMod = 1.0f;

    private int lastDay = 0;
    private int currentDay = 0;

    private int lastMonth = 0;
    private int currentMonth = 0;

    public float yield = 0.0f;
    public float yieldFactor = 0.0f;
    public float maxYield = 40.0f;

    private float growthFactor = 0.01f;

    private GameObject timer;

    private MeshFilter meshFilter;
    public Mesh initialMesh;
    public Mesh sproutMesh;
    public Mesh grownMesh;

    enum growthStage { initial = 0, sprout, grown, dead };    
    growthStage currentGrowthStage = growthStage.initial;

    enum moistureLevel { low = 0, medium, high };
    moistureLevel currentMoistureLevel = moistureLevel.low;

    Stack<moistureLevel> moistureLevels;

    void updateMoisture()
    {
        if (moisture <= 0.0f)
            return;

        float random = 0.0f;

        if (moisture > 100.0f)
            random = Random.Range(1.0f, 2.5f);

        if (moisture > 30.0f && moisture <= 100.0f)
        {
            random = Random.Range(0.0f, 0.4f);

            if(moisture <= 65.0f)
            {
                currentMoistureLevel = moistureLevel.medium;
            }            
            
            if(moisture > 65.0f)
            {
                currentMoistureLevel = moistureLevel.high;
            }
        }

        if (moisture <= 30.0f)
        {
            random = Random.Range(0.0f, 0.05f);
            currentMoistureLevel = moistureLevel.low;
        }
        moisture -= random;        
    }

    void updateMoistureMod()
    {
        if(moisture >= 20.0f)
            moistureMod = moisture / 100.0f;
    }

    void updateSeasonMod()
    {
        if (monthPlanted >= 3 && monthPlanted <= 5)
            seasonMod = 0.1f;

        else
            seasonMod = 0.05f;
    }

    void updateYield()
    {
        if (yield < maxYield && planted)
        {
            yield += (growthFactor + seasonMod + moistureMod);

            if (yield > (yieldFactor + 5.0f))
            {
                yieldFactor = Mathf.Round(yield);
            }
        }

        if (yield <= 10)
        {
            updateMesh(growthStage.initial);
            return;
        }

        if (yield > 10 && yield <= 50)
        {
            updateMesh(growthStage.sprout);
            return;
        }

        if(yield > 50)
        {
            updateMesh(growthStage.grown);
        }
    }

    void updateMesh(growthStage stage)
    {
        currentGrowthStage = stage;

        switch (currentGrowthStage)
        {
            case growthStage.initial:
                meshFilter.mesh = initialMesh;
                break;

            case growthStage.sprout:
                meshFilter.mesh = sproutMesh;
                break;

            case growthStage.grown:
                meshFilter.mesh = grownMesh;
                break;

            case growthStage.dead:

                break;
        }
    }

    void updateMaxYield()
    {
        float lowCount = 0.0f;
        float medCount = 0.0f;
        float highCount = 0.0f;

        foreach (moistureLevel ML in moistureLevels)
        {
            if (ML == moistureLevel.low)
                lowCount++;

            if (ML == moistureLevel.medium)
                medCount++;

            if (ML == moistureLevel.high)
                highCount++;
        }

        maxYield = (40.0f + (1.5f * lowCount) + (2.0f * medCount) + (2.5f * highCount));
    }

    public void addMoisture()
    {
        moisture += 10.0f;
    }

    public void plantPot()
    {
        planted = true;
        monthPlanted = timer.GetComponent<timeTracking>().getCurrentTime().monthNum;
        yieldFactor = 0;
        updateSeasonMod();
        moistureLevels.Clear();
        moistureLevels.Push(currentMoistureLevel);
    }

    void Start()
    {
      //  SaveSystem.clearBinaryFile();


        PlayerData data = SaveSystem.LoadPlayer();

        lastDay = data.day;
        currentDay = lastDay;

        lastMonth = data.currentMonth;
        currentMonth = lastMonth;
        monthPlanted = data.monthPlanted;

        planted = data.planted;

        yield = data.currentYield;
        yieldFactor = Mathf.Round(yield);

        timer = GameObject.Find("Timer");

        meshFilter = this.GetComponent<MeshFilter>();

        moistureLevels = new Stack<moistureLevel>();
    }

    void Update()
    {
        currentDay = timer.GetComponent<timeTracking>().getCurrentTime().day;
        currentMonth = timer.GetComponent<timeTracking>().getCurrentTime().monthNum;

        if (currentDay != lastDay)
        {
            lastDay = currentDay;

            updateMoisture();

            updateMoistureMod();

            updateYield();
        }

        if(currentMonth != lastMonth)
        {
            lastMonth = currentMonth;

            moistureLevels.Push(currentMoistureLevel);
            updateMaxYield();
        }

        if (plantable)
            planted = false;
    }
}