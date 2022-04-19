using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSprite_script : MonoBehaviour
{
    // The Following Code was written by Blair McCartan

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touchSwipeMethod();

        mouseSwipeMethod();
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
                Debug.Log("up spin swipe");
                transform.Rotate(Vector3.forward * -90);
            }
            //swipe down
            if (currentSwipe.y < 0 & (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f))
            {
                Debug.Log("down spin swipe");
                transform.Rotate(Vector3.forward * -90);
            }
            //swipe left
            if (currentSwipe.x < 0 & (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
            {
                Debug.Log("left spin swipe");
                transform.Rotate(Vector3.forward * -90);
            }
            //swipe right
            if (currentSwipe.x > 0 & (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
            {
                Debug.Log("right spin swipe");
                transform.Rotate(Vector3.forward * -90);
            }
        }
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
                    Debug.Log("up spin swipe");
                    transform.Rotate(Vector3.forward * -90);
                }

                //Swipe down 
                if (currentSwipe.y < 0 & (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f))
                {
                    Debug.Log("down spin swipe");
                    transform.Rotate(Vector3.forward * -90);
                }

                //Swipe left
                if (currentSwipe.x < 0 & (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
                {
                    Debug.Log("left spin swipe");
                    transform.Rotate(Vector3.forward * -90);
                }
                //swipe right
                if (currentSwipe.x > 0 & (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
                {
                    Debug.Log("right spin swipe");
                    transform.Rotate(Vector3.forward * -90);
                }
            }
        }
    }
    
    //End of code written by Blair McCartan
}
