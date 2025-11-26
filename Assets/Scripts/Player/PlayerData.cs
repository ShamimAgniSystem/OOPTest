using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int Health; 
    public int Score;
    public int scoreIncressValue;
    public int takeDamage;
    public List<string> Inventory;

    public PlayerData()
    {
        Health = 100;
        Score = 0;
        Inventory = new List<string>();
    }
}
