using System;
using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : SaveAndLoadData
{
    public PlayerData PlayerData;
    private void Awake()
    {
        object playerData = LoadData("PlayerData.json", PlayerData);
        
        if (playerData != null)
        {
            PlayerData = (PlayerData)playerData;
        }
        else InitializPlayerData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int updatedScore = ScoreUpdate(PlayerData.scoreIncressValue);
            GameEvents.UpdateScore(updatedScore);
        }
    }
    private void InitializPlayerData()
    {
        if (PlayerData == null)
        {
            Debug.LogError("Player Data is null");
            return;
        }
        PlayerData.Health = 100;
        PlayerData.Score = 0;
        PlayerData.scoreIncressValue = 10;
        PlayerData.takeDamage = 10;
        PlayerData.Inventory.Add("RPG");
    }
    public int ScoreUpdate(int score)
    {
        PlayerData.Score += score;
        SaveData(PlayerData,"PlayerData.json","Resourses");
        return score;
    }

    public int PlayerDamage(int damageValue,EnemyData enemyData)
    {
        //int life = GameEvents.UpdateLife(LifeDamege(enemyData.giveDamage));
        //GameEvents.UpdateLife(life);
        
        PlayerData.Score -= damageValue;
        if (PlayerData.Score <= 0)
        {
            GameEvents.OnPlayerDie();
        }
        return PlayerData.Score;
    }

    int LifeDamege(int damageValue)
    {
        return PlayerData.Score -= damageValue;
    }
    void DeathHandelar()
    {
        
    }
}
