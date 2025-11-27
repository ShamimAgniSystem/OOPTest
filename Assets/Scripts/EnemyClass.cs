using UnityEngine;

public class EnemyClass : CharacterBase
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    
    
    public override void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
    }
    public override void Heal(int heal)
    {
        throw new System.NotImplementedException();
    }
    public override int GetCurrentHealth()
    {
        throw new System.NotImplementedException();
    }
    public override void Move()
    {
        
    }
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}