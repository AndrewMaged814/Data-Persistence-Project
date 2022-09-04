using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public static class SaveSystem {

    public static void SavePlayer(string name, int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(name, score);

        Debug.Log("Data saved");
        Debug.Log("name: "+data.name+"Score: "+data.score);


        formatter.Serialize(stream, data);
        stream.Close();


    }
    public static PlayerData LoadPlayer()
    {
        try
        {
            string path = Application.persistentDataPath + "/player.fun";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();


                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }


        }
        catch (System.Exception e)
        {
            Debug.LogError("Error Loading Save " + e);
            return null;
        }
    }

}
