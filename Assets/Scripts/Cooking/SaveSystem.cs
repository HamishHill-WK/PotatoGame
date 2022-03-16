﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Code Written by Blair McCartan

public static class SaveSystem 
{
   public static void SavePlayer (potato playerPotato, soil playerSoil, timeTracking playerTime)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerPotato, playerSoil, playerTime);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void clearBinaryFile()    //Use when the binary file contains bad data - hh (Can't remember whether blair or I wrote this 16/3/22)
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Save File not found in " + path);

            return null;
        }
    }
}
