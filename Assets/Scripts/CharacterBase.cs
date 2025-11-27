using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public abstract void TakeDamage(int damage);
    public abstract void Heal(int heal);
    public abstract int GetCurrentHealth();
    public abstract void Move();
    public abstract void Attack();
}
public enum PlayerStates
{
    Idle,
    Running,
    Collecting,
    Delivering
}