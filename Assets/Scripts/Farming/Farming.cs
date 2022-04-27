using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script was written by Hamish Hill Github: @HamishHill-WK

public class Farming : MonoBehaviour
{
    public GameObject[] potatos = { null, null, null, null, null, null };
    private GameObject spade;
    private GameObject soil;
    private GameObject sphere;
    private GameObject inventory;
    private GameObject invPanel;
    private GameObject timer;

    private int[] potatoStocks = { 0, 0, 0, 0, 0, 0 };

    public int[] stocks;

    private bool plantable;
    private bool planted;

    public string potatoType = "none";
    
    enum selectable { none = 0, potatoObj, spade, inventory, water };
    selectable currentSelect = selectable.none;

    private MeshRenderer sphereMesh;
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
                if (hit.collider.gameObject == sphere)
                {
                    Selector(selectable.water);
                }

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

                if (hit.collider.gameObject.tag == "Potato")
                {
                    Selector(selectable.potatoObj);

                    potatoType = hit.collider.gameObject.name;

                    StartCoroutine(wait());
                }
                
                if (hit.collider.gameObject == spade)
                {
                    Selector(selectable.spade);
                }

                if (hit.collider.gameObject == soil)
                {
                    if (currentSelect == selectable.spade)
                    {
                        if (!plantable && !planted)
                        {
                            Selector(selectable.none);

                            soil.GetComponent<soil>().plantable = true;
                        }

                        if (planted)
                        {
                            Selector(selectable.none);

                            Harvest(soil.GetComponent<soil>().yield);

                            soil.GetComponent<soil>().planted = false;

                            soil.GetComponent<soil>().yield = 0.0f;
                        }
                    }

                    if (currentSelect == selectable.potatoObj)
                    {
                        if (plantable)
                        {
                            Selector(selectable.none);

                            soil.GetComponent<soil>().plantable = false;
                            soil.GetComponent<soil>().plantPot(potatoType);
                        }
                    }

                    if(currentSelect == selectable.water)
                    {
                        soil.GetComponent<soil>().addMoisture();
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
                sphereMesh.material = mat2;
                spadeMesh.material = mat2;
                invMesh.material = mat2;
                break;

            case selectable.potatoObj:
                sphereMesh.material = mat2;
                spadeMesh.material = mat2;
                invMesh.material = mat2;
                break;

            case selectable.spade:
                sphereMesh.material = mat2;
                spadeMesh.material = mat1;
                invMesh.material = mat2;
                break;

            case selectable.inventory:
                sphereMesh.material = mat2;
                spadeMesh.material = mat2;
                invMesh.material = mat1;
                break;            
            
            case selectable.water:
                sphereMesh.material = mat1;
                spadeMesh.material = mat2;
                invMesh.material = mat2;
                break;
        }
    }

    private void Harvest(float yield)
    {
        invPanel.SetActive(true);
        yield /= 10.0f;
        harvest = (int)Mathf.Round(yield);

        foreach (GameObject g in potatos)
        {
            Debug.Log("bloops");
            if (g.name == potatoType)
            {
                Debug.Log("loops");
                g.GetComponent<potato>().addStock(harvest);
            }
        }

        StartCoroutine(wait());
    }

    private void updateVars()
    {
        plantable = soil.GetComponent<soil>().plantable;
        planted = soil.GetComponent<soil>().planted;
    }

    private void startLoad()
    {
        spade = GameObject.Find("Spade");
        sphere = GameObject.Find("Watering");
        soil = GameObject.Find("Soil");
        inventory = GameObject.Find("Inventory");
        invPanel = GameObject.Find("invPanel");
        timer = GameObject.Find("Timer");

        potatos = GameObject.FindGameObjectsWithTag("Potato");

        StartCoroutine(wait());

        camera1 = Camera.main;

        sphereMesh = sphere.GetComponent<MeshRenderer>();
        spadeMesh = spade.GetComponent<MeshRenderer>();
        invMesh = inventory.GetComponent<MeshRenderer>();

        loadStock();
    }

    private void loadStock()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        List<int> values = data.totalPotatos;

        int i = 0;

        foreach (GameObject p in potatos)
        {
            p.GetComponent<potato>().setStock(values[i]);
            i++;
        }
    }   
    
    private void saveStock()
    {
        int i = 0;
        foreach (GameObject g in potatos)
        {
            potatoStocks[i] = g.GetComponent<potato>().getStock();
            i++;
        }
    }

    void Start()
    {
        startLoad();

        updateVars();
    }

    void Update()
    {
        userInput();

        updateVars();

        if(invPanel.activeInHierarchy)
            saveStock();

        SaveSystem.SavePlayer(potatoStocks, soil.GetComponent<soil>(), timer.GetComponent<timeTracking>());
    }
}