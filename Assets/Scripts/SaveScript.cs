using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static User user;
    public TMP_InputField inputName;
    private string savePath;
    public MainManager mainManager;
    void Start()
    {
        user = new User();
        savePath = Application.persistentDataPath + "gamesave.save";
        
    }

    public void SaveData()
    {
 
        user.UserName = inputName.text;
        user.UserScore = mainManager.highScore;
        var save = new Save()
        {
            savedName = user.UserName,
            savedScore = user.UserScore

        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath)){
            binaryFormatter.Serialize(fileStream, save);

        }
        Debug.Log("Data Saved");
        Debug.Log("\"Name: " + user.UserName);
        Debug.Log("\"score: " + user.UserScore);
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Debug.Log("Save Score: " + mainManager.highScore);
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using(var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            user.UserName = save.savedName;
            user.UserScore = save.savedScore;

            inputName.text = user.UserName;

            Debug.Log("Data Loaded");
            Debug.Log("\"Name: " + user.UserName);
            Debug.Log("\"score: " + user.UserScore);

        }
        else
        {
            Debug.LogWarning("Save file does't exist");
        }
    }
}
