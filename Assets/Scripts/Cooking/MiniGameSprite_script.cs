using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameSprite_script : MonoBehaviour
{
    /////////////////The following Script was written by Blair McCartan

    //References for the Game controller 
    private int recipeSel = 0;
    private int onMiniGame = 0;

    private GameObject gameController;

    private Text currentRecipe, currentMinigame, currentGuide;

    public Sprite[] backgroundSprites;

    //Prefabs 

    //Add minigame prefabs
    public Transform AddMinigamePrefab;
    private Transform AddMinigameGameObject;

    //References for the sprites in the game
    public Sprite[] recipe1Sprites;
    public Sprite[] PeelSprites;
    public Sprite[] BoilSprites;
    public Sprite[] AddSprites;
    public Sprite[] DrainSprites;
    public Sprite[] RoastSprites;
    public Sprite[] SliceSprites;
    public Sprite[] StirSprites;
    public Sprite[] MashSprites;
    
    public Sprite[] CompletedRecipeSprites;


    private Sprite[] referencedSprites;     //use the reference for the publically loaded sprites


    //Variables for the touch and swipe mechanics
    bool inputEnabled = false;      // This val is used in a short wait between inputs so the player doesnt instatnly finish a minigame

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;


    //Variables used in the minigame methods
    int noOfCuts = 1;
    int noOfBoil = 1;
    int noOfMash = 1;
    int noOfDrain = 1;
    int noOfRoast = 1;
    int noOfStir = 1;



    //////////// End of varaibles declaration ////////////


    // Start is called before the first frame update and will initialise the sprite
    void Start()
    {
        gameController = GameObject.Find("Game Controller");
        currentRecipe = GameObject.Find("Current Recipe Text - Text").GetComponent<Text>();
        currentMinigame = GameObject.Find("Current Recipe Minigame - Text").GetComponent<Text>();
        currentGuide = GameObject.Find("Current Recipe Guide - Text").GetComponent<Text>();

        recipeSel = gameController.GetComponent<RecipeBook_script>().recipeNumberSel;       //Get the selected recipe that the player has chosen 

        SwitchMiniGame();       //To start the minigames
    }



    void SwitchMiniGame()       //Here we call the start function for each minigame 
    {
        this.GetComponent<SpriteRenderer>().sprite = null;      //Hide the sprite during the changing of the minigame so it doesnt flash or show both
        onMiniGame++;       //change what minigame we are on 


        referencedSprites = recipe1Sprites;


        //Depending on what recipe we are doing 
        switch (recipeSel)
        {
            //First Recipe minigame set - Wedges 
            case 1:
                currentRecipe.text = "Potato Wedges";

                switch (onMiniGame)     // Switch based on the minigame we are on
                {
                    case 1:
                        BoilMiniGameStart();
                        break;

                    case 2:
                        SliceMiniGameStart();
                        break;

                    case 3:
                        AddMiniGameStart();
                        break;

                    case 4:
                        DrainMiniGameStart();
                        break;

                    case 5:
                        AddMiniGameStart();
                        break;

                    case 6:
                        AddMiniGameStart();
                        break;

                    case 7:
                        RoastMiniGameStart();
                        break;

                    case 8:
                        FinishedRecipe();
                        break;

                    case 9:
                        EndRecipe();
                        break;
                }
                break; 


            //Second Recipe minigame set - Mashed potatoes
            case 2:
                currentRecipe.fontSize = 45;
                currentRecipe.text = "Mashed Potatoes";

                switch (onMiniGame)
                {
                    case 1:
                        BoilMiniGameStart();        
                        break;

                    case 2:
                        AddMiniGameStart();
                        break;

                    case 3:
                        StirMiniGameStart();
                        break;

                    case 4:
                        DrainMiniGameStart();
                        break;

                    case 5:
                        AddMiniGameStart();
                        break;

                    case 6:
                        MashMiniGameStart();
                        break;

                    case 7:
                        AddMiniGameStart();
                        break;

                    case 8:
                        FinishedRecipe();
                        break;

                    case 9:
                        EndRecipe();
                        break;

                }
                break;
               

            case 3:     // - Crispy Roast 
                currentRecipe.text = "Crispy Roast";

                switch (onMiniGame)
                {
                    case 1:
                        PeelMiniGameStart();
                        break;

                    case 2:
                        BoilMiniGameStart();
                        break;

                    case 3:
                        AddMiniGameStart();
                        break;

                    case 4:
                        AddMiniGameStart();
                        break;

                    case 5:
                        DrainMiniGameStart();
                        break;

                    case 6:
                        AddMiniGameStart();
                        break;

                    case 7:
                        AddMiniGameStart();
                        break;

                    case 8:
                        RoastMiniGameStart();
                        break;

                    case 9:
                        FinishedRecipe();
                        break;

                    case 10:
                        EndRecipe();
                        break;

                }
                break;


            case 4:     // - Potato Salad
                currentRecipe.text = "Potato Salad";

                switch (onMiniGame)
                {
                    case 1:
                        AddMiniGameStart();
                        break;

                    case 2:
                        AddMiniGameStart();
                        break;

                    case 3:
                        BoilMiniGameStart();
                        break;

                    case 4:
                        DrainMiniGameStart();
                        break;

                    case 5:
                        AddMiniGameStart();
                        break;

                    case 6:
                        AddMiniGameStart();
                        break;

                    case 7:
                        AddMiniGameStart();
                        break;

                    case 8:
                        FinishedRecipe();
                        break;

                    case 9:
                        EndRecipe();
                        break;

                }
                break;


            case 5:     // - Baked Potatoes
                currentRecipe.text = "Baked Potatoes";

                switch (onMiniGame)
                {
                    case 1:
                        PeelMiniGameStart();
                        break;

                    case 2:
                        AddMiniGameStart();
                        break;

                    case 3:
                        BoilMiniGameStart();
                        break;

                    case 4:
                        DrainMiniGameStart();
                        break;

                    case 5:
                        RoastMiniGameStart();
                        break;

                    case 6:
                        AddMiniGameStart();
                        break;

                    case 7:
                        AddMiniGameStart();
                        break;

                    case 8:
                        FinishedRecipe();
                        break;  

                    case 9:
                        EndRecipe();
                        break;

                }
                break;


            case 6:     // - Chips
                currentRecipe.text = "Chips";

                switch (onMiniGame)
                {
                    case 1:
                        SliceMiniGameStart();
                        break;

                    case 2:
                        AddMiniGameStart();
                        break;

                    case 3:
                        BoilMiniGameStart();
                        break;

                    case 4:
                        DrainMiniGameStart();
                        break;

                    case 5:
                        AddMiniGameStart();
                        break;

                    case 6:
                        AddMiniGameStart();
                        break;

                    case 7:
                        RoastMiniGameStart();
                        break;

                    case 8:
                        AddMiniGameStart();
                        break;

                    case 9:
                        FinishedRecipe();
                        break;

                    case 10:
                        EndRecipe();
                        break;

                }
                break;
        }
    }

    void FinishedRecipe()
    {
        this.GetComponent<SpriteRenderer>().sprite = CompletedRecipeSprites[recipeSel];

        currentRecipe.text = "Complete";
        currentMinigame.text = "";
        currentGuide.text = "";

        if (Input.GetMouseButtonDown(0))
        {
            SwitchMiniGame();
        }
    }

    void EndRecipe()       //When a recipe is complete hide the guides and detroy the minigame object prefab
    {
        //Set all the guide boxes to be empty
        currentRecipe.text = "";
        currentMinigame.text = "";
        currentGuide.text = "";

        //Hide the guide boxes
        if (gameController.GetComponent<RecipeBook_script>().currentRecipe.activeInHierarchy == true)
            gameController.GetComponent<RecipeBook_script>().currentRecipe.SetActive(false);

        if (gameController.GetComponent<RecipeBook_script>().currentMinigame.activeInHierarchy == true)
            gameController.GetComponent<RecipeBook_script>().currentMinigame.SetActive(false);

        if (gameController.GetComponent<RecipeBook_script>().currentGuide.activeInHierarchy == true)
            gameController.GetComponent<RecipeBook_script>().currentGuide.SetActive(false);

        //Allow the player to start a new recipe and delete the minigame sprite
        gameController.GetComponent<RecipeBook_script>().inMiniGame = false;
        Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update()       //Switch the minigame based upon the recipe and current sequence
    {
        if (inputEnabled)
        {
            // Only the neccessary methods are called for each minigame
            switch (recipeSel)
            {

                case 1:     // - Potato Wedges 
                    switch (onMiniGame)
                    {
                        case 1:
                            BoilMiniGameUpdate();      // Start the potato cutting minigame
                            break;

                        case 2:
                            SliceMiniGameUpdate();
                            break;

                        case 3:
                            AddMiniGameUpdate();
                            break;

                        case 4:
                            DrainMiniGameUpdate();
                            break;

                        case 5:
                            AddMiniGameUpdate();
                            break;

                        case 6:
                            AddMiniGameUpdate();
                            break;

                        case 7:
                            RoastMiniGameUpdate();
                            break;

                        case 8:
                            FinishedRecipe();
                            break;

                        case 9:
                            EndRecipe();
                            break;

                    }
                    break;


                case 2:     // - Mashed Potatoes
                    switch (onMiniGame)
                    {
                        case 1:
                            BoilMiniGameUpdate();
                            break;

                        case 2:
                            AddMiniGameUpdate();
                            break;

                        case 3:
                            StirMiniGameUpdate();
                            break;

                        case 4:
                            DrainMiniGameUpdate();
                            break;

                        case 5:
                            AddMiniGameUpdate();
                            break;

                        case 6:
                            MashMiniGameUpdate();
                            break;

                        case 7:
                            AddMiniGameUpdate();
                            break;

                        case 8:
                            FinishedRecipe();
                            break;

                        case 9:
                            EndRecipe();
                            break;
                    }
                    break;


                case 3:    // - Crispy Roast 
                    switch (onMiniGame)
                    {
                        case 1:
                            PeelMiniGameUpdate();
                            break;

                        case 2:
                            BoilMiniGameUpdate();
                            break;

                        case 3:
                            AddMiniGameUpdate();
                            break;

                        case 4:
                            AddMiniGameUpdate();
                            break;

                        case 5:
                            DrainMiniGameUpdate();
                            break;

                        case 6:
                            AddMiniGameUpdate();
                            break;

                        case 7:
                            AddMiniGameUpdate();
                            break;

                        case 8:
                            RoastMiniGameUpdate();
                            break;

                        case 9:
                            FinishedRecipe();
                            break;

                        case 10:
                            EndRecipe();
                            break;
                    }
                    break;


                case 4:     // - Potato Salad
                    currentRecipe.text = "Potato Salad";

                    switch (onMiniGame)
                    {
                        case 1:
                            AddMiniGameUpdate();
                            break;

                        case 2:
                            AddMiniGameUpdate();
                            break;

                        case 3:
                            BoilMiniGameUpdate();
                            break;

                        case 4:
                            DrainMiniGameUpdate();
                            break;

                        case 5:
                            AddMiniGameUpdate();
                            break;

                        case 6:
                            AddMiniGameUpdate();
                            break;

                        case 7:
                            AddMiniGameUpdate();
                            break;

                        case 8:
                            FinishedRecipe();
                            break;

                        case 9:
                            EndRecipe();
                            break;

                    }
                    break;


                case 5:     // - Baked Potatoes
                    currentRecipe.text = "Baked Potatoes";

                    switch (onMiniGame)
                    {
                        case 1:
                            PeelMiniGameUpdate();
                            break;

                        case 2:
                            AddMiniGameUpdate();
                            break;

                        case 3:
                            BoilMiniGameUpdate();
                            break;

                        case 4:
                            DrainMiniGameUpdate();
                            break;

                        case 5:
                            RoastMiniGameUpdate();
                            break;

                        case 6:
                            AddMiniGameUpdate();
                            break;

                        case 7:
                            AddMiniGameUpdate();
                            break;

                        case 8:
                            FinishedRecipe();
                            break;

                        case 9:
                            EndRecipe();
                            break;

                    }
                    break;


                case 6:     // - Chips
                    currentRecipe.text = "Chips";

                    switch (onMiniGame)
                    {
                        case 1:
                            SliceMiniGameUpdate();
                            break;

                        case 2:
                            AddMiniGameUpdate();
                            break;

                        case 3:
                            BoilMiniGameUpdate();
                            break;

                        case 4:
                            DrainMiniGameUpdate();
                            break;

                        case 5:
                            AddMiniGameUpdate();
                            break;

                        case 6:
                            AddMiniGameUpdate();
                            break;

                        case 7:
                            RoastMiniGameUpdate();
                            break;

                        case 8:
                            AddMiniGameUpdate();
                            break;

                        case 9:
                            FinishedRecipe();
                            break;

                        case 10:
                            EndRecipe();
                            break;
                    }
                    break;
            }
        }

        inputEnabled = false;

        StartCoroutine(ResumeInputMethod());
    }


    IEnumerator ResumeInputMethod()
    {
        yield return new WaitForSecondsRealtime(1);
        inputEnabled = true;
    }


    /// <summary>
    /// Start of Minigame Functions ///////
    /// </summary>


    int ReturnSwipeControlsVertical()
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
            if (currentSwipe.y > 0 & (currentSwipe.x > -1.0f || currentSwipe.x < 1.0f))
            {
                Debug.Log("return swipe - up swipe");
                return 1;
            }
            //swipe down
            if (currentSwipe.y < 0 & (currentSwipe.x > -1.0f || currentSwipe.x < 1.0f))
            {
                Debug.Log("return swipe - down swipe");
                return 2;
            }
                        
        }
        return 0;       //No swipe detected
    }
    
    int ReturnSwipeControlsHorizontal()
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
            if (currentSwipe.x < 0 & (currentSwipe.y > -1.0f || currentSwipe.y < 1.0f))
            {
                Debug.Log(" return swipe -left swipe");
                return 1;

            }

            //swipe right
            if (currentSwipe.x > 0 & (currentSwipe.y > -1.0f || currentSwipe.y < 1.0f))
            {
                Debug.Log("return swipe - right swipe");
                return 2;
            }     
        }
        return 0;       //No swipe detected
    }

    //Minigame Methods

    void PeelMiniGameStart()
    {
        referencedSprites = PeelSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[0];

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        currentMinigame.text = "Peel";
        currentGuide.text = "Swipe Up";
    }

    void PeelMiniGameUpdate()
    {
        if (ReturnSwipeControlsVertical() == 1)
        {
            noOfCuts++;
            SoundManager.PlaySound("Peel"); //calls sound from SoundManager Script - hs
        }
            

        switch (noOfCuts)       //As the player cuts update the image of the sprite too
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

            case 12:
                SwitchMiniGame();
                break;
        }
    }


    void BoilMiniGameStart()
    {
        referencedSprites = BoilSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[2];


        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        currentMinigame.text = "Boil";
    }

    void BoilMiniGameUpdate()
    {
        switch (noOfBoil)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
                currentGuide.text = "Tap";

                if (Input.GetMouseButtonDown(0))
                {
                    noOfBoil++;
                    SoundManager.PlaySound("Boil"); //calls sound from SoundManager Script - hs
                }
                    
                    
                break;

            case 2:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[1];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                    noOfBoil++;

                break;

            case 3:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[2];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                    noOfBoil++;

                break;

            case 4:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[3];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                    noOfBoil++;

                break;

            case 5:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[4];
                currentGuide.text = "Tap";

                if (Input.GetMouseButtonDown(0))
                    noOfBoil++;

                break;

            case 6:
                SwitchMiniGame();
                break;
        }
    }



    void AddMiniGameStart()
    {
        referencedSprites = AddSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[0];

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
        this.transform.position = new Vector3(-1.5f, 0.5f, -3.5f);

        AddMinigameGameObject = Instantiate(AddMinigamePrefab, new Vector3(1.5f, 2.0f, -3.1f), Quaternion.identity);

        currentMinigame.text = "Add";
        currentGuide.text = "Swipe Left";
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
                SoundManager.PlaySound("Add"); //calls sound from SoundManager Script - hs
                Destroy(AddMinigameGameObject.gameObject);

                this.transform.position = new Vector3(0.20f, 2.0f, -3.1f); 

                SwitchMiniGame();
            }
        }
    }



    void DrainMiniGameStart()
    {
        referencedSprites = DrainSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[1];

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        currentMinigame.text = "Drain";
    }

    void DrainMiniGameUpdate()
    {
        switch (noOfDrain)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
                currentGuide.text = "Tap";

                if (Input.GetMouseButtonDown(0))
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }

                break;

            case 2:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[1];
                currentGuide.text = "Swipe Left";

                if (ReturnSwipeControlsHorizontal() == 1)
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }
                break;

            case 3:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[2];
                currentGuide.text = "Swipe Right";

                if (ReturnSwipeControlsHorizontal() == 2)
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }
                break;

            case 4:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[3];
                currentGuide.text = "Swipe Left";

                if (ReturnSwipeControlsHorizontal() == 1)
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }
                break;

            case 5:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[4];
                currentGuide.text = "Swipe Right";

                if (ReturnSwipeControlsHorizontal() == 2)
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }
                break;

            case 6:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[5];
                currentGuide.text = "Swipe Left";

                if (ReturnSwipeControlsHorizontal() == 1)
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }
                break;

            case 7:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[6];
                currentGuide.text = "Swipe Right";

                if (ReturnSwipeControlsHorizontal() == 2)
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }
                break;

            case 8:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[7];
                currentGuide.text = "Tap";

                if (Input.GetMouseButtonDown(0))
                {
                    SoundManager.PlaySound("Watering"); //calls sound from SoundManager Script - hs
                    noOfDrain++;
                }
                break;

            case 9:
                SwitchMiniGame();
                break;
        }
    }



    IEnumerator RoastWait()
    {
        yield return new WaitForSecondsRealtime(3);
        noOfRoast++;
    }

    void RoastMiniGameStart()
    {
        referencedSprites = RoastSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[2];

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        currentMinigame.text = "Roast";
    }

    void RoastMiniGameUpdate()
    {
        switch (noOfRoast)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
                currentGuide.text = "Tap";

                if (Input.GetMouseButtonDown(0))
                    noOfRoast++;

                break;

            case 2:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[1];
                currentGuide.text = "Swipe Up";

                if (ReturnSwipeControlsVertical() == 1)
                {
                    noOfRoast++;
                }
                break;

            case 3:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[2];
                currentGuide.text = "Waiting";

                StartCoroutine(RoastWait());

                break;

            case 4:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[3];
                currentGuide.text = "Swipe Down";

                if (ReturnSwipeControlsVertical() == 2)
                {
                    noOfRoast++;
                }
                break;

            case 5:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[4];
                currentGuide.text = "Tap";

                if (Input.GetMouseButtonDown(0))
                    noOfRoast++;
                break;

            case 6:
                SwitchMiniGame();
                break;
        }
    } 

    void SliceMiniGameStart()
    {
        referencedSprites = SliceSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[0];

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        currentMinigame.text = "Slice";
        currentGuide.text = "Swipe Down";
    }

    void SliceMiniGameUpdate()
    {
        if (ReturnSwipeControlsVertical() == 2)
        {
            noOfCuts++;
            SoundManager.PlaySound("Slice"); //calls sound from SoundManager Script - hs
        }
            


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

            case 12:
                SwitchMiniGame();
                break;


        }
    }


    //This is the wait used in some minigames
    IEnumerator StirWait()
    {
        yield return new WaitForSecondsRealtime(1);
        noOfStir++;
    }

    void StirMiniGameStart()
    {
        referencedSprites = StirSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[1];

        currentMinigame.text = "Stir";
    }

    void StirMiniGameUpdate()
    {
        switch (noOfStir)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                {
                    SoundManager.PlaySound("Stir"); //calls sound from SoundManager Script - hs
                    noOfStir++;
                }
                break;

            case 2:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[1];
                currentGuide.text = "Waiting";

                // wait for 1 second
                StartCoroutine(StirWait());
                break;

            case 3:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[2];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                {
                    noOfStir++;
                }
                break;

            case 4:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[3];
                currentGuide.text = "Waiting";

                // wait for 1 second
                StartCoroutine(StirWait());
                break;

            case 5:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[4];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                {
                    noOfStir++;
                }
                break;

            case 6:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[5];
                currentGuide.text = "Waiting";

                // wait for 1 second
                StartCoroutine(StirWait());
                break;

            case 7:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[6];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                {
                    noOfStir++;
                }
                break;

            case 8:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[7];
                currentGuide.text = "Waiting";

                // wait for 1 second
                StartCoroutine(StirWait());
                break;

            case 9:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[8];
                currentGuide.text = "Swipe";

                if (ReturnSwipeControlsHorizontal() != 0 || ReturnSwipeControlsVertical() != 0)
                {
                    noOfStir++;
                }
                break;

            case 10:
                this.GetComponent<SpriteRenderer>().sprite = referencedSprites[9];
                currentGuide.text = "Waiting";

                // wait for 1 second
                StartCoroutine(StirWait());
                break;

            case 11:
                SwitchMiniGame();

                break;
        }
    }



    //Mash and add are the same in the reference sheet
    void MashMiniGameStart()
    {
        referencedSprites = MashSprites;
        GameObject.Find("Background").GetComponent<Image>().sprite = backgroundSprites[0];

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];

        currentMinigame.text = "Mash";
        currentGuide.text = "Tap";
    }

    void MashMiniGameUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            noOfMash++;
        }

        switch (noOfMash)
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
                SwitchMiniGame();
                break;
        }

        //Do something else to switch the minigame 
    }


    /////////////////End of script written by Blair McCartan
}
