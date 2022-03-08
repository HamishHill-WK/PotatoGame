using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //Code Written by Blair McCartan

    public int score;
    public int health;
    public float[] position;

    public int totalPotatos;

    public PlayerData(potato playerPotatos)
    {
        totalPotatos = playerPotatos.stock;

        //level = player.level;
        //health = player.health;

        position = new float[3];
        //position[0] = .transform.po
    }

    //https://www.youtube.com/watch?v=XOjd_qU2Ido

    //End of code written by Blair McCartan
}
