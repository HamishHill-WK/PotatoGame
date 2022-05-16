using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecipeBookObject_script : MonoBehaviour
{
    //The following Code was written by Blair McCartan 

    public GameObject v_gameController;
    private RecipeBook_script v_recipeBook_script;

    public Canvas recipeBook;
    public GameObject recipePanel;

    public int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Get obejct References
        GameObject tempObject = GameObject.Find("Recipebook Canvas");

        if (tempObject != null)
        {
            recipeBook = tempObject.GetComponent<Canvas>();
            if (recipeBook == null)
            {
                Debug.Log("Could not locate canvas object on " + tempObject.name);
            }
        }

        Button btn = this.GetComponent<Button>();       //When clicking the button carry out he following method
        btn.onClick.AddListener(TaskOnClicked);
    }

    void OnMouseDown()      //For Unity legacy ver - same as method below
    {
        Debug.Log("Panel button doesnt work");

        v_recipeBook_script = v_gameController.GetComponent<RecipeBook_script>();

        if (v_recipeBook_script.inMiniGame == false)
        {
            if (recipeBook.enabled == false)
            {
                recipeBook.enabled = true;

                if (recipePanel.activeInHierarchy == true)
                    recipePanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log("In a minigame");
        }
    }

    void TaskOnClicked()
    {
        //Debug.Log("Panel button works");

        v_recipeBook_script = v_gameController.GetComponent<RecipeBook_script>();

        if (v_recipeBook_script.inMiniGame == false)        //if not in a minigame
        {
            if (recipeBook.enabled == false)
            {
                recipeBook.enabled = true;

                if (recipePanel.activeInHierarchy == true)      //activate it in the heirarchy
                    recipePanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log("In a minigame");     //Prevent the player from starting another recipe
        }
    }

    //End of Code Written By Blair McCartan
}
