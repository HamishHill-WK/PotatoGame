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
    public Transform prefab;        //Test prefab



    private GameObject recipeBookObject;
    private Button recipe1Button;

    private Button proceedButton;
    

    //Recipe text references

    private Text recipeIng, recipeMethod, recipeMiniGames;


    public bool inMiniGame = false;


    // Start is called before the first frame update
    void Start()
    {
        //Get obejct References
        GameObject tempObject = GameObject.Find("Recipebook Canvas");
        recipe1Button = GameObject.Find("Recipe 1 Button").GetComponent<Button>();


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

        proceedButton = GameObject.Find("Proceed Button").GetComponent<Button>();
        proceedButton.onClick.AddListener(miniGame1Test);


        recipeBook.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");

            //recipeBook.enabled = false;

            showFirstRecipe();
        }
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

    void showFirstRecipe()
    {
        if (recipePanel.activeInHierarchy == false)
            recipePanel.SetActive(true);

        textSetup();


        recipeIng.text = "Recipe Ingredients";

        recipeMethod.text = "Recipe Method";

        recipeMiniGames.text = "Recipe Minigames";


    }

    void miniGame1Test()
    {
        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }

        inMiniGame = true;

        Debug.Log("This button works ");

        Instantiate(prefab, new Vector3(0.20f, 2.0f, -0.1f), Quaternion.Euler(45.0f, 0.0f, 0.0f));
    }

    //End of code written by Blair McCartan
}
