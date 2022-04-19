using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Touch and click Class and method
public class swipeDetection_script : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public Material material1;
    public Material material2;
    public GameObject testObject;

    private void Update()
    {
        touchSwipeMethod();

        mouseSwipeMethod();
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
                }

                //Swipe down 
                if (currentSwipe.y < 0 & (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f))
                {
                    Debug.Log("Down Swipe");
                }

                //Swipe left
                if (currentSwipe.x < 0 & (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
                {
                    Debug.Log("left swipe");
                }
                //swipe right
                if (currentSwipe.x > 0 & (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
                {
                    Debug.Log("right swipe");
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
            if (currentSwipe.y > 0 & (currentSwipe.x > -0.5f  || currentSwipe.x < 0.5f))
            {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0 & (currentSwipe.x > -0.5f  || currentSwipe.x < 0.5f))
            {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 & (currentSwipe.y > -0.5f  || currentSwipe.y < 0.5f))
            {
                Debug.Log("left swipe");
            }
            //swipe right
            if (currentSwipe.x > 0 & (currentSwipe.y > -0.5f  || currentSwipe.y < 0.5f))
            {
                Debug.Log("right swipe");
            }
        }
    }

}


// Third option
//public class swipeDetection_script : MonoBehaviour
//{
//    private Vector2 fingerDownPos;
//    private Vector2 fingerUpPos;

//    public bool detectSwipeAfterRelease = false;

//    public float SWIPE_THRESHOLD = 20f;

//    // Update is called once per frame
//    void Update()
//    {

//        foreach (Touch touch in Input.touches)
//        {
//            if (touch.phase == TouchPhase.Began)
//            {
//                fingerUpPos = touch.position;
//                fingerDownPos = touch.position;
//            }

//            //Detects Swipe while finger is still moving on screen
//            if (touch.phase == TouchPhase.Moved)
//            {
//                if (!detectSwipeAfterRelease)
//                {
//                    fingerDownPos = touch.position;
//                    DetectSwipe();
//                }
//            }

//            //Detects swipe after finger is released from screen
//            if (touch.phase == TouchPhase.Ended)
//            {
//                fingerDownPos = touch.position;
//                DetectSwipe();
//            }
//        }
//    }

//    void DetectSwipe()
//    {

//        if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
//        {
//            Debug.Log("Vertical Swipe Detected!");
//            if (fingerDownPos.y - fingerUpPos.y > 0)
//            {
//                OnSwipeUp();
//            }
//            else if (fingerDownPos.y - fingerUpPos.y < 0)
//            {
//                OnSwipeDown();
//            }
//            fingerUpPos = fingerDownPos;

//        }
//        else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
//        {
//            Debug.Log("Horizontal Swipe Detected!");
//            if (fingerDownPos.x - fingerUpPos.x > 0)
//            {
//                OnSwipeRight();
//            }
//            else if (fingerDownPos.x - fingerUpPos.x < 0)
//            {
//                OnSwipeLeft();
//            }
//            fingerUpPos = fingerDownPos;

//        }
//        else
//        {
//            Debug.Log("No Swipe Detected!");
//        }
//    }

//    float VerticalMoveValue()
//    {
//        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
//    }

//    float HorizontalMoveValue()
//    {
//        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
//    }

//    void OnSwipeUp()
//    {
//        //Do something when swiped up
//    }

//    void OnSwipeDown()
//    {
//        //Do something when swiped down
//    }

//    void OnSwipeLeft()
//    {
//        //Do something when swiped left
//    }

//    void OnSwipeRight()
//    {
//        //Do something when swiped right
//    }

   
//}
