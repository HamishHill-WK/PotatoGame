using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potato : MonoBehaviour
{
    public bool selected = false;

    public int stock = 0;

    public Text txt;

    public void addStock(int add)
    {
        stock += add;
    }

    // Start is called before the first frame update
    void Start()
    {
        //txt = GameObject.Find("Text");

        PlayerData data = SaveSystem.LoadPlayer();      // Loading the saved number of potatoes - BM

        stock = data.totalPotatos;      //Setting the number of potatoes from the stock saved value - BM
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = stock.ToString();

        SaveSystem.SavePlayer(this);
    }
}
