﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoCutting_script : MonoBehaviour
{
    // The Following Code was written by Blair McCartan

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    int noOfCuts = 1;

    public Sprite[] potatoSprites;
    //var potato2Sprite : Sprite;
    //var potato3Sprite : Sprite;
    //var potato4Sprite : Sprite;
    //var potato5Sprite : Sprite;
    //var potato6Sprite : Sprite;
    //var potato7Sprite : Sprite;
    //var potato8Sprite : Sprite;
    //var potato9Sprite : Sprite;
    //var potato10Sprite : Sprite;
    //var potato11Sprite : Sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        touchSwipeMethod();

        mouseSwipeMethod();

        updatePotato();
    }

    public void touchSwipeMethod()
    {

        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                // Save began touch 2d print 
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                // Save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                // Create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                // Normalize the 2d Vector 
                currentSwipe.Normalize();


                //Swie Actions 

                // Swipe upwards
                if (currentSwipe.y > 0 & (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f))
                {
                    Debug.Log("Up Swipe");

                    noOfCuts++;
                }

                //Swipe down 
                if (currentSwipe.y < 0 & (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f))
                {
                    Debug.Log("Down Swipe");

                    noOfCuts++;
                }
            }
        }
    }


    //Update is called once per frame
    public void mouseSwipeMethod()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 & (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f))
            {
                Debug.Log("up swipe");

                noOfCuts++;
            }
            //swipe down
            if (currentSwipe.y < 0 & (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f))
            {
                Debug.Log("down swipe");

                noOfCuts++;
            }
        }
    }

    public void updatePotato()
    {
        switch (noOfCuts)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[0];
                break;

            case 2:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[1];
                break;

            case 3:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[2];
                break;

            case 4:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[3];
                break;

            case 5:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[4];
                break;

            case 6:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[5];
                break;

            case 7:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[6];
                break;

            case 8:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[7];
                break;

            case 9:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[8];
                break;

            case 10:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[9];
                break;

            case 11:
                this.GetComponent<SpriteRenderer>().sprite = potatoSprites[10];
                break;
        }
    }


    //End of code written by Blair McCartan
}