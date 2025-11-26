using  System;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    private int _health = 100;

    public int Health => _health;
    
    // Events && Delegates...
    public delegate void DamageTaken(int damage);
    public delegate void OnHealed(int heal);
    public delegate void OnDed();
    
    public event DamageTaken OnDamageTaken;   
    public event OnHealed OnHealthHealed;
    public event OnDed OnDeath;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(10);
        if (Input.GetKeyDown(KeyCode.H))
            Heal(10);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _health = Mathf.Max(0, _health);
        OnDamageTaken?.Invoke(damage);
        if (_health <= 0)
        {
            Debug.Log("Dies");
            OnDeath?.Invoke();
        }
    }
    public void Heal(int heal)
    {
        heal = Mathf.Max(0, heal);
        _health += heal;
        _health = Mathf.Clamp(_health,0,100);
        OnHealthHealed?.Invoke(heal);
    }
    public int GetCurrentHealth() => _health;
}
