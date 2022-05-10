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

    //Prefab references 
    public Transform MinigamePrefab;
    public int recipeSelection;

    public Transform potatoPrefab;        //Test prefab
    public Transform boilPrefab;        //Test prefab
    

    private int test = 2;

    private GameObject recipeBookObject;
    private Button recipe1Button;
    private Button recipe2Button;
    private Button recipe3Button;
    private Button recipe4Button;
    private Button recipe5Button;
    private Button recipe6Button;

    private Button proceedButton;
    private Button returnToRecipesButton;
    

    //Recipe text references

    private Text recipeIng, recipeMethod, recipeMiniGames;


    //Misc Variables
    public bool inMiniGame = false;
    private int recipeNumberSel;

    public GameObject currentRecipe, currentMinigame, currentGuide;


    // Start is called before the first frame update
    void Start()
    {
        //Get obejct References
        GameObject tempObject = GameObject.Find("Recipebook Canvas");
        recipe1Button = GameObject.Find("Recipe 1 Button").GetComponent<Button>();
        recipe2Button = GameObject.Find("Recipe 2 Button").GetComponent<Button>();
        recipe3Button = GameObject.Find("Recipe 3 Button").GetComponent<Button>();
        recipe4Button = GameObject.Find("Recipe 4 Button").GetComponent<Button>();
        recipe5Button = GameObject.Find("Recipe 5 Button").GetComponent<Button>();
        recipe6Button = GameObject.Find("Recipe 6 Button").GetComponent<Button>();


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

        ////Recipe 3 button
        Button rep3Btn = recipe3Button.GetComponent<Button>();
        rep3Btn.onClick.AddListener(showThirdRecipe);

        ////Recipe 4 button
        Button rep4Btn = recipe4Button.GetComponent<Button>();
        rep4Btn.onClick.AddListener(showFourthRecipe);

        ////Recipe 5 button
        Button rep5Btn = recipe5Button.GetComponent<Button>();
        rep5Btn.onClick.AddListener(showFifthRecipe);

        ////Recipe 6 button
        Button rep6Btn = recipe6Button.GetComponent<Button>();
        rep6Btn.onClick.AddListener(showSixthRecipe);


        //In recipe panel Butoons

        proceedButton = GameObject.Find("Proceed Button").GetComponent<Button>();
        proceedButton.onClick.AddListener(selectRecipeMethod);

        //returnToRecipesButton = GameObject.Find("Return to Recipes Button").GetComponent<Button>();
        //returnToRecipesButton.onClick.AddListener(returnToRecipesMethod);


        recipeBook.enabled = false;
    }

    void exitRecipeBook()
    {
        // this object was clicked - do something

        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }

        if (currentRecipe.activeInHierarchy == true)
            currentRecipe.SetActive(false);

        if (currentMinigame.activeInHierarchy == true)
            currentMinigame.SetActive(false);

        if (currentGuide.activeInHierarchy == true)
            currentGuide.SetActive(false);
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
        if (recipePanel.activeInHierarchy == false)
            recipePanel.SetActive(true);

        if (recipeBook.enabled == false)
        {
            recipeBook.enabled = true;
        }

        //Get txt object references     // MUST GO AFTER LISTENERS ELSE STOPS AT TRYING TO FIND THEM
        recipeIng = GameObject.Find("Recipe Ingredients").GetComponent<Text>();
        recipeMethod = GameObject.Find("Recipe Method").GetComponent<Text>();
        recipeMiniGames = GameObject.Find("Minigames Involved").GetComponent<Text>();
    }

    void showFirstRecipe()
    {
        recipeNumberSel = 1;        //used for the switch statement on the proceed button (avoids loads of button finds)

        textSetup();

        //vb filling in the data for wedges
        recipeIng.text = "Ingedients: 3 Baking Potatoes, olive oil, salt";
        
        recipeMethod.text = "Simple Potato Wedges enjoyable as a snack or as a side dish";

        recipeMiniGames.text = "Boil - Slice - add - drain - add - add - Roast";
    }

    void showSecondRecipe()
    {
        recipeNumberSel = 2;        //used for the switch statement on the proceed button (avoids loads of button finds)

        textSetup();

        recipeIng.text = "Ingedients: Potato " + test.ToString();

        recipeMethod.text = "Simple Mashed Potatoes";

        recipeMiniGames.text = "Boil - Add - Stir - Drain - Add - Mash - Add";
    }

    void showThirdRecipe()
    {
        recipeNumberSel = 3;

        textSetup();

        recipeIng.text = "Ingedients: Potato " + test.ToString();

        recipeMethod.text = "Crispy Roast Potatoes";

        recipeMiniGames.text = "Peel - Boil - Add - Add - Drain - Add - Add - Roast";
    }

    void showFourthRecipe()
    {
        recipeNumberSel = 4;

        textSetup();

        recipeIng.text = "Ingedients: Potato " + test.ToString();

        recipeMethod.text = "Potato Salad";

        recipeMiniGames.text = "Add - Add - Boil - Drain - Add - Add - Add";
    }

    void showFifthRecipe()
    {
        recipeNumberSel = 5;

        textSetup();

        recipeIng.text = "Ingedients: Potato " + test.ToString();

        recipeMethod.text = "Baked Potatoes";

        recipeMiniGames.text = "Peel - Add - Boil - Drain - Roast - Add - Add";
    }

    void showSixthRecipe()
    {
        recipeNumberSel = 6;

        textSetup();

        recipeIng.text = "Ingedients: Potato " + test.ToString();

        recipeMethod.text = "Chips";

        recipeMiniGames.text = "Slice - Add - Boil - Drain - Add - Ad - Roast - Add";
    }


    void selectRecipeMethod()
    {
        inMiniGame = true;

        switch (recipeNumberSel)
        {
            case 1:
                firstRecipe();
                break;

            case 2:
                secondRecipe();
                break;

            case 3:
                thirdRecipe();
                break;

            case 4:
                fourthRecipe();
                break;
            
            case 5:
                fifthRecipe();
                break;

            case 6:
                sixthRecipe();
                break;
        }
    }

    //Changing recipes
    void changeRecipeSetUp()
    {
        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }

        if (currentRecipe.activeInHierarchy == false)
            currentRecipe.SetActive(true);

        if (currentMinigame.activeInHierarchy == false)
            currentMinigame.SetActive(true);

        if (currentGuide.activeInHierarchy == false)
            currentGuide.SetActive(true);
    }

    void firstRecipe()
    {
        changeRecipeSetUp();

        recipeSelection = 1;

        Instantiate(MinigamePrefab, new Vector3(0.20f, 2.0f, -3.1f), Quaternion.identity);
    }

    void secondRecipe()
    {
        changeRecipeSetUp();

        recipeSelection = 2;

        Instantiate(MinigamePrefab, new Vector3(0.20f, 2.0f, -3.1f), Quaternion.identity);
    }

    void thirdRecipe()
    {
        changeRecipeSetUp();

        recipeSelection = 3;

        Instantiate(MinigamePrefab, new Vector3(0.20f, 2.0f, -3.1f), Quaternion.identity);
    }

    void fourthRecipe()
    {
        changeRecipeSetUp();

        recipeSelection = 4;

        Instantiate(MinigamePrefab, new Vector3(0.20f, 2.0f, -3.1f), Quaternion.identity);
    }

    void fifthRecipe()
    {
        changeRecipeSetUp();

        recipeSelection = 5;

        Instantiate(MinigamePrefab, new Vector3(0.20f, 2.0f, -3.1f), Quaternion.identity);
    }

    void sixthRecipe()
    {
        changeRecipeSetUp();

        recipeSelection = 6;

        Instantiate(MinigamePrefab, new Vector3(0.20f, 2.0f, -3.1f), Quaternion.identity);
    }



    //End of code written by Blair McCartan
}
