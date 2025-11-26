using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public class GameEvents
{
    public static Action OnPlayerDeath;
    public static Action<int> OnScoreUpdated;
    public static Action<int> OnGetHitted;
    
    public Action<int> OnEnemyHit;

    //public static int UpdateLife(int damage) => OnGetHitted?.Invoke(damage);
    public static void OnPlayerDie() => OnPlayerDeath?.Invoke();
    public static void UpdateScore(int score) => OnScoreUpdated?.Invoke(score);
}
