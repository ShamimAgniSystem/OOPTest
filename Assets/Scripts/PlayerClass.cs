using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerClass : CharacterBase
{
    private int _health = 100;
    public int Health => _health;
    
    
    [Header("Components")]
    [SerializeField] private CharacterController m_CharacterController;
    
    [Header("Movement Variables")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private Vector3 inputVector;

    [Header("States")]
    public PlayerStates CurrentState { get; set; } = PlayerStates.Idle;

    // Delegates
    public delegate void DamageTaken(int damage);
    public delegate void OnHealed(int heal);
    public delegate void OnDed();

    // Events
    public event DamageTaken OnDamageTaken;
    public event OnHealed OnHealthHealed;
    public event OnDed OnDeath;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    public override void TakeDamage(int damage)
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

    public override void Heal(int heal)
    {
        heal = Mathf.Max(0, heal);
        _health += heal;
        _health = Mathf.Clamp(_health, 0, 100);
        OnHealthHealed?.Invoke(heal);
    }

    public override int GetCurrentHealth() => _health;

    public override void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        inputVector = new Vector3(h, 0, v).normalized;
        m_CharacterController.Move(inputVector * (speed * Time.deltaTime));
        Rotate(inputVector);
    }

    public void Rotate(Vector3 direction)
    {
        if (direction.magnitude > 0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public override void Attack()
    {
        Debug.Log("Player Attack!");
    }
}