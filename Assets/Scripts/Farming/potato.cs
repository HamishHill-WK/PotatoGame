using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script was written by Hamish Hill github: @HamishHill-WK

public class potato : MonoBehaviour
{
    public bool selected = false;

    public int stock = 0;

    public Text txt;

    public void addStock(int add)
    {
        stock += add;

        SaveSystem.SavePlayer(this, null, null);
    }

    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        stock = data.totalPotatos;
    }

    void Update()
    {
        txt.text = stock.ToString();
    }
}
