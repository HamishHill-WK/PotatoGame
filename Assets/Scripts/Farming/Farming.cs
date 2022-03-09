using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script was written by Hamish Hill Github: @HamishHill-WK

public class Farming : MonoBehaviour
{
    private GameObject potato;
    private GameObject spade;
    private GameObject soil;
    private GameObject inventory;
    private GameObject invPanel;

    private bool plantable;
    private bool planted;

    enum selectable { none = 0, potato, spade, inventory };
    selectable currentSelect = selectable.none;

    //private MeshRenderer potatoMesh;
    private MeshRenderer spadeMesh;
    private MeshRenderer invMesh;

    public Material mat1;
    public Material mat2;

    private int harvest;

    private Camera camera1;
    private Ray ray;
    private RaycastHit hit;

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1);
        invPanel.SetActive(false);
    }

    private void userInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = camera1.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject == inventory)
                {
                    if (currentSelect == selectable.inventory)
                    {
                        invPanel.SetActive(false);

                        Selector(selectable.none);

                        return; //without this inventory cannot be closed
                    }

                    if (currentSelect != selectable.inventory)
                    {
                        invPanel.SetActive(true);

                        Selector(selectable.inventory);
                    }
                }

                if (hit.collider.gameObject == potato)
                {
                    Selector(selectable.potato);

                    Debug.Log("potato ");

                    StartCoroutine(wait());
                }
                
                if (hit.collider.gameObject == spade)
                {
                    Selector(selectable.spade);
                }   

                if (hit.collider.gameObject == soil && currentSelect == selectable.spade )
                {
                    if (!plantable && !planted)
                    {
                        Selector(selectable.none);

                        soil.GetComponent<soil>().plantable = true;
                    }

                    if(planted)
                    {
                        Selector(selectable.none);

                        Harvest(soil.GetComponent<soil>().yield);

                        soil.GetComponent<soil>().planted = false;

                        soil.GetComponent<soil>().yield = 0.0f;
                    }
                }            
                
                if (hit.collider.gameObject == soil && currentSelect == selectable.potato )
                {
                    if (plantable)
                    {
                        Selector(selectable.none);

                        soil.GetComponent<soil>().plantable = false;
                        soil.GetComponent<soil>().planted = true;
                    }
                }
            }
        }
    }

    private void Selector(selectable object1)
    {
        currentSelect = object1;
        switch (currentSelect)
        {
            case selectable.none:
               // potatoMesh.material = mat2;
                spadeMesh.material = mat2;
                invMesh.material = mat2;
                break;

            case selectable.potato:
               // potatoMesh.material = mat1;
                spadeMesh.material = mat2;
                invMesh.material = mat2;
                break;

            case selectable.spade:
               // potatoMesh.material = mat2;
                spadeMesh.material = mat1;
                invMesh.material = mat2;
                break;

            case selectable.inventory:
                //potatoMesh.material = mat2;
                spadeMesh.material = mat2;
                invMesh.material = mat1;
                break;
        }
    }

    private void Harvest(float yield)
    {
        yield /= 10.0f;
        harvest = (int)Mathf.Round(yield);
        potato.GetComponent<potato>().addStock(harvest);
    }

    private void updateVars()
    {
        plantable = soil.GetComponent<soil>().plantable;
        planted = soil.GetComponent<soil>().planted;
    }

    private void startLoad()
    {
        potato = GameObject.Find("Potato");
        spade = GameObject.Find("Spade");
        soil = GameObject.Find("Soil");
        inventory = GameObject.Find("Inventory");
        invPanel = GameObject.Find("invPanel");

        invPanel.SetActive(false);

        camera1 = Camera.main;

        //potatoMesh = potato.GetComponent<MeshRenderer>();
        spadeMesh = spade.GetComponent<MeshRenderer>();
        invMesh = inventory.GetComponent<MeshRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        startLoad();

        updateVars();
    }

    // Update is called once per frame
    void Update()
    {
        userInput();

        updateVars();
    }
}
 