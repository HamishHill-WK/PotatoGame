using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil : MonoBehaviour
{
    public bool plantable = false;
    public bool planted = false;

    public float yield = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plantable)
            planted = false;

        if (planted)
        {
            if(yield < 100.0f)
                yield += .01f;
        }   
    }
}
