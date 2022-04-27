using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script was written by Hamish Hill GitHub: @HamishHill-WK
//this script assigns names to potato objects from the "potatoNames.txt" file

public class potatoTypes : MonoBehaviour
{
    public TextAsset nameFile;
    public string[] fileNames = null;
    public GameObject potatoPrefab;

    private GameObject[] potatoes = {null, null, null, null, null, null};

    private Vector3 assetLocation = new Vector3( 0, 0, 0 );

    void Start()
    {
        fileNames = nameFile.text.Split('\n');

        for (int j = 0; j < 5; j++)
        {
            Debug.Log("loop");
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
                    assetLocation = new Vector3(-190, 25, -63);
                    break;

                case 4:
                    assetLocation = new Vector3(32, 25, -63);
                    break;

                case 5:
                    assetLocation = new Vector3(254, 25, -63);
                    break;
            }

            potatoes[j].transform.SetParent(transform);
            potatoes[j] = Instantiate(potatoPrefab, assetLocation, Quaternion.identity);
        }

        int i = 0;
        foreach (Transform child in transform)
        {
            child.GetComponent<potato>().setName(fileNames[i]);
            i++;
        }
    }
}
