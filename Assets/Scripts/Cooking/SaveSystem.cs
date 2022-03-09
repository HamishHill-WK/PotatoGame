using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    //The following code was written by Blair McCartan
    public static void SavePlayer (potato playerPotato)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        //Set the path to be consistent with the application
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerPotato);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        //Set the path to be consistent with the application
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

    //End of code written by Blair McCartan
}
