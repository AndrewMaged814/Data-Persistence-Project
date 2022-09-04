using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    private string userName;
    private int userScore;
    public User()
    {
    }
    public User(string userName, int userScore)
    {
        UserName = userName;
        UserScore = userScore;
    }

    public string UserName { get => userName; set => userName = value; }
    public int UserScore { get => userScore; set => userScore = value; }
}
