using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        v_recipeBook_script = v_gameController.GetComponent<RecipeBook_script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //Debug.Log("Hello world this click was detected");
        // this object was clicked - do something

        //Debug.Log(totalScore);

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

    //End of Code Written By Blair McCartan
}
