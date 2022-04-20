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
    public Text nameTxt;

    private string varName = "potato";

    public void addStock(int add)
    {
        stock += add;

        if (stock >= 99)
            stock = 99;

        txt.text = stock.ToString();

    }

    public void setStock(int add)
    {
        stock = add;
        txt.text = stock.ToString();
    }

    public int getStock()
    {
        return stock;
    }

    void Start()
    {
        //PlayerData data = SaveSystem.LoadPlayer();

        //stock = data.totalPotatos;

        txt.text = stock.ToString();
    }

}
