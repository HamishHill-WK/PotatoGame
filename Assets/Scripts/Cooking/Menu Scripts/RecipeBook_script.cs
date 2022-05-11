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

    //Misc Variables
    public bool inMiniGame = false;
    public int recipeNumberSel;

    public Transform potatoPrefab;        //Test prefab
    public Transform boilPrefab;        //Test prefab

    // Recipe References 
    private GameObject recipeBookObject;
    private Button recipe1Button;
    private Button recipe2Button;
    private Button recipe3Button;
    private Button recipe4Button;
    private Button recipe5Button;
    private Button recipe6Button;

    // Recipe Panel buttons
    private Button proceedButton;
    private Button returnToRecipesButton;
    
    //Recipe text references
    private Text recipeIng, recipeMethod, recipeMiniGames;

    // Minigame guide references (only used to be turned on)
    public GameObject currentRecipe, currentMinigame, currentGuide;


    


    // Start is called before the first frame update
    void Start()
    {
        //Find and get object References for the recipe buttons
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



        //Setup for recipe buttons
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


        //In recipe panel Butons
        proceedButton = GameObject.Find("Proceed Button").GetComponent<Button>();
        proceedButton.onClick.AddListener(selectRecipeMethod);      //When clicked run this method

        //returnToRecipesButton = GameObject.Find("Return to Recipes Button").GetComponent<Button>();
        //returnToRecipesButton.onClick.AddListener(returnToRecipesMethod);


        recipeBook.enabled = false;     // Make sure that the recipebook is not showing at the start when loading in
    }

    void exitRecipeBook()
    {
        // Close the recipebook canvas and stop showing the minigame guides 

        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }

        if (currentRecipe.activeInHierarchy == true)
            currentRecipe.SetActive(false);     //Hide the current recipe label

        if (currentMinigame.activeInHierarchy == true)
            currentMinigame.SetActive(false);   //Hide the current minigame label

        if (currentGuide.activeInHierarchy == true)
            currentGuide.SetActive(false);      //Hide the current input guide label
    }


    //Text set up for the recipes
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

        recipeIng.text = "1.5kg floury potato, 125ml Semi Skimmed Milk, 1tbsp butter, 4tbsp Creme Fraiche";

        recipeMethod.text = "A delicious creamy mash with reduced fat calories";

        recipeMiniGames.text = "Boil - Add - Stir - Drain - Add - Mash - Add";
    }

    void showThirdRecipe()
    {
        recipeNumberSel = 3;        //used for the switch statement on the proceed button (avoids loads of button finds)

        textSetup();

        recipeIng.text = "4tbsp oil, 1.5kg potato, 50g butter, 1/2 bunch of lemon thyme, 6 garlic cloves, lightly bashed, 1tbsp sea salt";

        recipeMethod.text = "Crispy roast potatoes with a fluffy middle and golden crisp exterior";

        recipeMiniGames.text = "Peel - Boil - Add - Add - Drain - Add - Add - Roast";
    }

    void showFourthRecipe()
    {
        recipeNumberSel = 4;        //used for the switch statement on the proceed button (avoids loads of button finds)

        textSetup();

        recipeIng.text = "600g of Potatoes, halving large ones. 2tsp vinegar, 2spt virgin olive oil, 120g mayonnaise, 1.5 tbsp Dijon Mustard, 1/2 red onion, 2tsp capers, parsely chives";

        recipeMethod.text = "A vegan Potato salid, great as a side";

        recipeMiniGames.text = "Add - Add - Boil - Drain - Add - Add - Add";
    }

    void showFifthRecipe()
    {
        recipeNumberSel = 5;        //used for the switch statement on the proceed button (avoids loads of button finds)

        textSetup();

        recipeIng.text = "700g, 1tbsp olive oil, 30g butter, 150g yogurt, 6 spring onions, 200g sweetcorn, 150g cheese, chives";

        recipeMethod.text = "Baked Potatoes as a healthy homemade meal";

        recipeMiniGames.text = "Peel - Add - Boil - Drain - Roast - Add - Add";
    }

    void showSixthRecipe()
    {
        recipeNumberSel = 6;        //used for the switch statement on the proceed button (avoids loads of button finds)

        textSetup();

        recipeIng.text = "4-5 large potatoes. 5tbsp vegetable oil, 1tsbs pepper. 1 onion. 2 peppers, 2 garlic cloves, 1 red chilli, 1tbsp salt, or preference of seasoning";

        recipeMethod.text = "Delicious Chips seasoned to taste";

        recipeMiniGames.text = "Slice - Add - Boil - Drain - Add - Ad - Roast - Add";
    }


    void selectRecipeMethod()
    {
        inMiniGame = true;      //var true so we cant re open the recipebook until finished

        changeRecipeSetUp();
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

        Instantiate(MinigamePrefab, new Vector3(0.20f, 2.0f, -3.1f), Quaternion.identity);      //Create the minigame prefab
    }

    //End of code written by Blair McCartan
}
