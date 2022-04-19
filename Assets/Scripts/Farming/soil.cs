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

    public float yield = 0.0f;
    public float yieldFactor = 0.0f;

    private float growthFactor = 0.01f;

    private GameObject timer;

    private MeshFilter meshFilter;
    public Mesh initialMesh;
    public Mesh sproutMesh;
    public Mesh grownMesh;

    enum growthStage { initial = 0, sprout, grown, dead };    
    growthStage currentGrowthStage = growthStage.initial;

    void updateMoisture()
    {
        if (moisture <= 0.0f)
            return;

        float random = 0.0f;

        if (moisture > 100.0f)
            random = Random.Range(1.0f, 2.5f);

        if(moisture > 30.0f && moisture <= 100.0f)
            random = Random.Range(0.0f, 0.4f);
        
        if(moisture <= 30.0f)
            random = Random.Range(0.0f, 0.05f);

        moisture -= random;        
    }

    void updateMoistureMod()
    {
        if(moisture >= 20.0f)
            moistureMod = moisture / 100.0f;
    }

    void updateSeasonMod()
    {
        if (monthPlanted == 3)
            seasonMod = 0.1f;

        else
            seasonMod = 0.05f;
    }

    void updateYield()
    {
        if (yield < 100.0f && planted)
        {
            yield += (growthFactor + seasonMod + moistureMod);

            if (yield > (yieldFactor + 5.0f))
            {
                //   Debug.Log("yield updated");
                yieldFactor = Mathf.Round(yield);
               // SaveSystem.SavePlayer(null, this, null);
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
                // code block
                // meshFilter.sharedMesh = Resources.Load<Mesh>("teapotOBJ");
                meshFilter.mesh = initialMesh;
                break;

            case growthStage.sprout:
                // code block
                // meshFilter.sharedMesh = Resources.Load<Mesh>("Sphere");
                meshFilter.mesh = sproutMesh;
                break;
            case growthStage.grown:
                // code block
                //meshFilter.sharedMesh = Resources.Load<Mesh>("Cube");
                meshFilter.mesh = grownMesh;
                break;
            case growthStage.dead:
                // code block
                //meshFilter.sharedMesh = Resources.Load<Mesh>("body");

                break;
        }

        //this.GetComponent<MeshFilter>().sharedMesh = meshFilter.sharedMesh;
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

        //SaveSystem.SavePlayer(null, this, null);
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

        meshFilter = this.GetComponent<MeshFilter>();
       // meshFilter.sharedMesh = Resources.Load<Mesh>("teapotOBJ");
    }

    // Update is called once per frame
    void Update()
    {
        currentDay = timer.GetComponent<timeTracking>().getCurrentTime().day;

        if (currentDay != lastDay)
        {
            lastDay = currentDay;

            updateMoisture();

            updateMoistureMod();

            updateYield();
        }

        if (plantable)
            planted = false;
    }
}
