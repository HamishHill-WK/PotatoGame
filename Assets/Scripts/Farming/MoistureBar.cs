using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoistureBar : MonoBehaviour
{
    // Get reference to Soil object // CM
    public GameObject soilObj;
    private soil Soil;

    // Value Variables // CM
    public float startValue;

    // Slider Changes // CM
    public Slider bar;

    private float currentMoisture;

    void Start()
    {
        // Hides the object using the canvas group component // CM
        gameObject.GetComponent<CanvasGroup>().alpha = 0;

        Soil = soilObj.GetComponent<soil>();

        // Set progress bar value to start value // CM
        startValue = Soil.moisture;
    }

    // Update is called once per frame
    void Update()
    {
        currentMoisture = Soil.moisture;
        bar.value = currentMoisture;
    }

    // CM
}
