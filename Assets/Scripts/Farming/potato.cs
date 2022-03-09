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

    void Update()
    {
        txt.text = stock.ToString();
    }
}
