using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script was written by Hamish Hill GitHub: @HamishHill-WK
//this script instantiates potato objects in the player's inventory and assigns names to potato objects from the "potatoNames.txt" file

public class potatoTypes : MonoBehaviour
{
    public TextAsset nameFile;
    public string[] fileNames = null;
    public GameObject potatoPrefab;

    private GameObject[] potatoes = {null, null, null, null, null, null};
    private GameObject controller;

    private Vector3 assetLocation = new Vector3( 0, 0, 0 );

    void Start()
    {
        controller = GameObject.Find("GameController");
        fileNames = nameFile.text.Split('\n');

        for (int j = 0; j < 6; j++)
        {
            switch (j)      //BM
            {
                case 0:
                    assetLocation = new Vector3(-190, 50, -63);
                    break;

                case 1:
                    assetLocation = new Vector3(32, 50, -63);
                    break;

                case 2:
                    assetLocation = new Vector3(254, 50, -63);
                    break;

                case 3:
                    assetLocation = new Vector3(-190, -50, -63);
                    break;

                case 4:
                    assetLocation = new Vector3(32, -50, -63);
                    break;

                case 5:
                    assetLocation = new Vector3(254, -50, -63);
                    break;
            }

            potatoes[j] = Instantiate(potatoPrefab, new Vector3(0,0,0), Quaternion.identity);
            potatoes[j].transform.SetParent(transform);
            potatoes[j].transform.localScale = new Vector3(1, 1, 1);
            potatoes[j].transform.localPosition = assetLocation;
        }

        controller.GetComponent<Farming>().potatos = potatoes;

        int i = 0;
        foreach (Transform child in transform)
        {
            child.GetComponent<potato>().setName(fileNames[i]);
            i++;
        }
    }
}
