using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Get reference to Soil object // CM
    public GameObject soilObj;
    private soil Soil;

    // Value Variables // CM
    public float startValue;
    private float value;

    // Slider Changes // CM
    public Slider bar;

    // Text Changes // CM
    public Text barText;
    public Text labelText;

    void Start()
    {
        // Hides the object using the canvas group component // CM
        gameObject.GetComponent<CanvasGroup>().alpha = 0;

        Soil = soilObj.GetComponent<soil>();

        // Set progress bar value to start value // CM
        value = startValue;
    }

    void Update()
    {
        // Toggle the progress bars visibility and updates the bar and the text // CM
        if (Soil.planted == true)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            bar.value = Soil.yield;
            barText.text = Soil.yield.ToString("F2");

            // Add growing text later
                // Code Here
        }

        // Hide bar when it reaches max // CM
        if (Soil.yield >= 100 || Soil.planted == false) //added or planted equals false to check - hh
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 0; // Add gradual fade later
            value = startValue;
        }
    }

    // Code by Corey Mitchell
}
