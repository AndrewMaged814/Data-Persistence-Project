using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    //public static User user;
    //public TMP_InputField inputName;
    //public TMP_Text highScoreText;
    //private string savePath;
    //void Start()
    //{
    //    user = new User();
    //    savePath = Application.persistentDataPath + "gamesave.save";
        
    //}

    //public void SaveData()
    //{
 
    //    user.UserName = inputName.text;
    //    var save = new PlayerData()
    //    {
    //        savedName = user.UserName,
    //        score = user.UserScore

    //    };
    //    var binaryFormatter = new BinaryFormatter();
    //    using (var fileStream = File.Create(savePath)){
    //        binaryFormatter.Serialize(fileStream, save);

    //    }
    //    Debug.Log("Data Saved");
    //    Debug.Log("\"Name: " + user.UserName);
    //    Debug.Log("\"score: " + user.UserScore);
    //}

    //public void LoadData()
    //{
    //    if (File.Exists(savePath))
    //    {
    //        PlayerData save;

    //        var binaryFormatter = new BinaryFormatter();
    //        using(var fileStream = File.Open(savePath, FileMode.Open))
    //        {
    //            save = (PlayerData)binaryFormatter.Deserialize(fileStream);
    //        }

    //        user.UserName = save.savedName;
    //        user.UserScore = save.score;

    //        inputName.text = user.UserName;
    //        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

    //        Debug.Log("Data Loaded");
    //        Debug.Log("\"Name: " + user.UserName);
    //        Debug.Log("\"score: " + user.UserScore);

    //    }
    //    else
    //    {
    //        Debug.LogWarning("Save file does't exist");
    //    }
    //}
}
