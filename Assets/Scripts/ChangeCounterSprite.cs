using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCounterSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite basicCounter;
    public Sprite ovenCounter;
    public Sprite sinkCounter;

    public bool basicOn;
    public bool ovenOn;
    public bool sinkOn;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        basicOn = true;
        ovenOn = false;
        sinkOn = false;
    }

    void Update()
    {
        if (basicOn == true)
        {
            spriteRenderer.sprite = basicCounter;
        }
        
        if (ovenOn == true)
        {
            spriteRenderer.sprite = ovenCounter;
        }

        if (sinkOn == true)
        {
            spriteRenderer.sprite = sinkCounter;
        }
    }

    // Code by Corey Mitchell
}
