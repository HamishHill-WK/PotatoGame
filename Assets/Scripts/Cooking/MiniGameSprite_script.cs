using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSprite_script : MonoBehaviour
{
    /////////////////The following Script was written by Blair McCartan

    //References for the Game controller 
    private int miniGameSel;
    private int onMiniGame = 0;
    
    private GameObject gameController;

    //Prefabs 
    public Transform AddMinigamePrefab;
    public Transform AddMinigameGameObject;

    //References for the sprites in the game
    public Sprite[] recipe1Sprites;
    public Sprite[] recipe2Sprites;

    private Sprite[] referencedSprites;

    //Variables for the touch and swipe mechanics
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;


    //Variables used in the minigame methods
    int noOfCuts = 1;



    //////////// End of varaibles declaration ////////////


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Game Controller");

        miniGameSel = gameController.GetComponent<RecipeBook_script>().miniGameSelection;


        SwitchMiniGame();
    }

    void SwitchMiniGame()
    {
        this.GetComponent<SpriteRenderer>().sprite = null;
        onMiniGame++;

        switch (miniGameSel)
        {
            default:
                break;

            //First Recipe minigame set
            case 1:
                //PotatoCuttingMiniGame();        // Start the potato cutting minigame
                switch (onMiniGame)
                {
                    default:

                        //If no more minigames
                        break;

                    case 1:
                        PotatoCuttingMiniGameStart();        // Start the potato cutting minigame
                        break;

                    case 2:
                        AddMiniGameStart();
                        break;

                    case 3:
                        gameController.GetComponent<RecipeBook_script>().inMiniGame = false;
                        Destroy(this.gameObject);
                        break;

                }
                break;


            //Second Recipe minigame set
            case 2:
                AddMiniGameStart();


                break;

            case 3:
                BoilMiniGameStart();


                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Only the neccessary methds are called for each minigame
        switch (miniGameSel)
        {
            default:
                break;

            case 1:
                switch (onMiniGame)
                {
                    default:
                        //No more minigames;
                        break;


                    case 1:
                        PotatoCuttingUpdate();

                        break;

                    case 2:

                        AddMiniGameUpdate();
                        break;

                    
                }
                break;



            case 2:
                //referencedSprites = recipe2Sprites;

                AddMiniGameUpdate();

                break;

            case 3:

                //BoilMiniGame();

                break;
        }
    }

    



    //Minigame Methods
    void PotatoCuttingMiniGameStart()
    {
        //Debug.Log("Potato Cutting");

        referencedSprites = recipe1Sprites;

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        // Above Testing  


    }    

    public void cuttingTouchSwipeMethod()
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

    public void cuttingMouseSwipeMethod()
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

    public void PotatoCuttingUpdate()
    {
        cuttingMouseSwipeMethod();
        cuttingTouchSwipeMethod();

        switch (noOfCuts)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
                break;

            case 2:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[1];
                break;

            case 3:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[2];
                break;

            case 4:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[3];
                break;

            case 5:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[4];
                break;

            case 6:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[5];
                break;

            case 7:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[6];
                break;

            case 8:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[7];
                break;

            case 9:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[8];
                break;

            case 10:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[9];
                break;

            case 11:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[10];
                break;
        }

        if (noOfCuts >= 12)
        {
            this.transform.position += new Vector3(0, 0.005f, 0.005f);
        }

        if (this.transform.position.y > 2.5f)
        {
            SwitchMiniGame();
        }
    }


    void BoilMiniGameStart()
    {
        //Debug.Log("Potato Boiling");

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        // Above Testing  


    }

    void BoilMiniGameUpdate()
    {

    }

    void AddMiniGameStart()
    {
        referencedSprites = recipe2Sprites;

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        this.transform.position = new Vector3(-1.5f, 0.5f, -3.5f);

        AddMinigameGameObject = Instantiate(AddMinigamePrefab, new Vector3(1.5f, 2.0f, -3.1f), Quaternion.identity);
    }



    void AddMiniGameUpdate()
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

            //swipe left
            if (currentSwipe.x < 0 & (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
            {
                Debug.Log("Salted Potato");

                Destroy(AddMinigameGameObject.gameObject);

                SwitchMiniGame();
            }
        }
    }

    /////////////////End of script written by Blair McCartan
}
