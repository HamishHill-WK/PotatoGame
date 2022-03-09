using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil : MonoBehaviour
{
    public bool plantable = false;
    public bool planted = false;

    public float yield = 0.0f;
    public float growth = 0.01f;

    public float moisture = 10.0f;
    public float moistureMod = 1.0f;

    void updateMoisture()
    {
        float random = 0;
        random = Random.Range(0.0f, 0.4f) ;
        moisture -= random;
    }

    void updateMoistMod()
    {
        moistureMod = 
    }

    void updateGrowth()
    {

        growth *= moistureMod;
    }

    void Update()
    {
        updateMoisture();

        if (plantable)
            planted = false;

        if (planted)
        {
            if (yield < 100.0f)
                yield += growth;
        }   
    }
}
