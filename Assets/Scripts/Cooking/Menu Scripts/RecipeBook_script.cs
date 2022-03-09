using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecipeBook_script : MonoBehaviour
{
    //Following code written by Blair McCartan
    
    //Declare Objects
    public Canvas recipeBook;
    public GameObject recipePanel;
    public Button backButton;
    public Transform potatoPrefab;        //Test prefab
    public Transform boilPrefab;        //Test prefab



    private GameObject recipeBookObject;
    private Button recipe1Button;
    private Button recipe2Button;

    private Button proceedButton;
    private Button returnToRecipesButton;
    

    //Recipe text references

    private Text recipeIng, recipeMethod, recipeMiniGames;


    //Misc Variables
    public bool inMiniGame = false;
    private int recipeNumberSel;


    // Start is called before the first frame update
    void Start()
    {
        //Get obejct References
        GameObject tempObject = GameObject.Find("Recipebook Canvas");
        recipe1Button = GameObject.Find("Recipe 1 Button").GetComponent<Button>();
        recipe2Button = GameObject.Find("Recipe 2 Button").GetComponent<Button>();


        if (tempObject != null)
        {
            recipeBook = tempObject.GetComponent<Canvas>();
            if (recipeBook == null)
            {
                Debug.Log("Could not locate canvas object on " + tempObject.name);
            }
        }



        //Setup for buttons
        //Back Button
        Button backBtn = backButton.GetComponent<Button>();
        backBtn.onClick.AddListener(exitRecipeBook);

        //Recipe 1 button
        Button rep1Btn = recipe1Button.GetComponent<Button>();
        rep1Btn.onClick.AddListener(showFirstRecipe);
        
        //Recipe 2 button
        Button rep2Btn = recipe2Button.GetComponent<Button>();
        rep2Btn.onClick.AddListener(showSecondRecipe);







        //In recipe panel Butoons

        proceedButton = GameObject.Find("Proceed Button").GetComponent<Button>();
        proceedButton.onClick.AddListener(selectRecipeMethod);
        
        returnToRecipesButton = GameObject.Find("Return to Recipes Button").GetComponent<Button>();
        returnToRecipesButton.onClick.AddListener(returnToRecipesMethod);


        recipeBook.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    print("space key was pressed");

        //    //recipeBook.enabled = false;

        //    showFirstRecipe();
        //}
    }
    

    void exitRecipeBook()
    {
        Debug.Log("Hello world this back button click was detected");
        // this object was clicked - do something

        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }
    }


    //Text Set Up
    void showFirstRecipeProto()
    {
        GameObject RecipeButton = GameObject.Find("Recipe 1 Button");


        GameObject newGO = new GameObject("myTextGo");
        newGO.transform.SetParent(RecipeButton.transform);
        //newGO.transform.position = RecipeButton.transform.position;
        newGO.layer = 5;

        Text myText = newGO.AddComponent<Text>();
        myText.text = "Ta-dah!";
        myText.alignment = TextAnchor.MiddleCenter;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        myText.font = ArialFont;
        myText.material = ArialFont.material;
        myText.fontSize = 25;
    }

    void textSetup()
    {
        if (recipeBook.enabled == false)
        {
            recipeBook.enabled = true;
        }


        //Get txt object references     // MUST GO AFTER LISTENERS ELSE STOPS AT TRYING TO FIND THEM
        recipeIng = GameObject.Find("Recipe Ingredients").GetComponent<Text>();
        recipeMethod = GameObject.Find("Recipe Method").GetComponent<Text>();
        recipeMiniGames = GameObject.Find("Minigames Involved").GetComponent<Text>();
    }

    void returnToRecipesMethod()
    {
        if (recipePanel.activeInHierarchy == true)
            recipePanel.SetActive(false);

        //Debug.Log("Return to recipe books ");
    }

    void showFirstRecipe()
    {
        recipeNumberSel = 1;        //used for the switch statement on the proceed button (avoids loads of button finds)

        if (recipePanel.activeInHierarchy == false)
            recipePanel.SetActive(true);

        textSetup();


        recipeIng.text = "Ingedients: Potato";

        recipeMethod.text = "Cut the potato";

        recipeMiniGames.text = "Cutting Potato";

    }

    void showSecondRecipe()
    {
        recipeNumberSel = 2;        //used for the switch statement on the proceed button (avoids loads of button finds)

        if (recipePanel.activeInHierarchy == false)
            recipePanel.SetActive(true);

        textSetup();


        recipeIng.text = "Ingedients: Potato 2";

        recipeMethod.text = "Stir the potato 2";

        recipeMiniGames.text = "Boil the potato 2";
    }



    void selectRecipeMethod()
    {
        inMiniGame = true;

        switch (recipeNumberSel)
        {
            case 1:
                firstRecipeTest();
                break;

            case 2:
                secondRecipe();
                break;


        }
    }

    void firstRecipeTest()
    {
        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }

        Debug.Log("Do first recipe ");
        
        Instantiate(potatoPrefab, new Vector3(0.20f, 2.0f, -0.1f), Quaternion.Euler(45.0f, 0.0f, 0.0f));

        //inMiniGame = false;

    }

    void secondRecipe()
    {
        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }

        Debug.Log("Do Second Recipe");

        Instantiate(boilPrefab, new Vector3(0.20f, 2.0f, -0.1f), Quaternion.Euler(45.0f, 0.0f, 0.0f));

        
    }

    //End of code written by Blair McCartan
}
