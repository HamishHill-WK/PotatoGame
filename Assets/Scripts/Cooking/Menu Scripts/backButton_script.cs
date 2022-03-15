using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backButton_script : MonoBehaviour
{
    public Canvas recipeBook;
    public Button myButton;

   

    // Start is called before the first frame update
    void Start()
    {

        GameObject tempObject = GameObject.Find("Recipebook Canvas");

        if (tempObject != null)
        {
            recipeBook = tempObject.GetComponent<Canvas>();
            if (recipeBook == null)
            {
                Debug.Log("Could not locate canvas object on " + tempObject.name);
            }
        }


        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClicked);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClicked()
    {
        Debug.Log("Hello world this back button click was detected");
        // this object was clicked - do something

        if (recipeBook.enabled == true)
        {
            recipeBook.enabled = false;
        }
    }
}
