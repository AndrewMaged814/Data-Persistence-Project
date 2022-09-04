using System;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static User user;
    public TMP_InputField inputName;
    public TMP_Text HighScoreText;
    public static GameManager Instance;
    private void Awake()
    {
        user = new User();

        if (Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(inputName.text, 0);

    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        user.UserName = data.name;
        user.UserScore = data.score;
        Debug.Log("Name " + user.UserName + "Score" + user.UserScore);

        ShowDatatoMenu();
    }
    public void UpdatePlayerScore( int score)
    {
        SaveSystem.SavePlayer(inputName.text, score);

        user.UserScore = score;
    }


    public void ShowDatatoMenu()
    {
        inputName.text = user.UserName;
        HighScoreText.text = "HighScore: "+ user.UserScore.ToString();

    }

}
