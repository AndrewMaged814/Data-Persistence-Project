using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int score;
    public string name;

    public PlayerData(string name, int score)
    {
        this.score = score;
        this.name = name;
    }

}
