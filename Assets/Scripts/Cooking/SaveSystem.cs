using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    static int[] potatoDef = { 0, 0, 0, 0, 0, 0 };
    static soil soilDef = new soil();
    static timeTracking timeDef = new timeTracking();

    public static void SavePlayer (int[] playerPotato, soil playerSoil, timeTracking playerTime)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.data";      //make sure that the file path stays with the application as opposed to being put in c:: drive 
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerPotato, playerSoil, playerTime);     //create a new data stream

        formatter.Serialize(stream, data);      //convert the data to be put in
        stream.Close();     //Close to prevent memory leak
    }

    public static void clearBinaryFile()
    {
        Debug.Log("file cleared");
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(potatoDef, soilDef, timeDef);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;      //convert the data in the file back
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Save File not found in " + path);       //if data file not found

            return null;
        }
    }
}