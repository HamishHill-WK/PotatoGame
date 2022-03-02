using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil : MonoBehaviour
{
    public bool plantable = false;
    public bool planted = false;

    private float moisture = 10.0f;

    public float yield = 0.0f;
    public float growthFactor = 0.01f;

    void updateMoisture()
    {
        float random;
        random = Random.Range(0.0f, 0.4f);
        moisture -= random;
    }

    void updateGrowth()
    {
        //growthFactor *= 
    }

    // Update is called once per frame
    void Update()
    {
        if (plantable)
            planted = false;


        if (yield < 100.0f && planted)
            yield += .01f;      
    }
}
