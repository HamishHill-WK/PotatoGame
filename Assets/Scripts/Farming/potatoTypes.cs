using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script was written by Hamish Hill GitHub: @HamishHill-WK
//this script assigns names to potato objects from the "potatoNames.txt" file

public class potatoTypes : MonoBehaviour
{
    public TextAsset nameFile;
    public string[] fileNames = null;

    void Start()
    {
        fileNames = nameFile.text.Split('\n');

        int i = 0;
        foreach (Transform child in transform)
        {
            child.GetComponent<potato>().setName(fileNames[i]);
            i++;
        }
    }
}
