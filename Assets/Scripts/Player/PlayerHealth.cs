using System;
using UnityEngine;
using UnityEngine.Events;

public enum HealthType
{
    Red,
    Yellow,
    Green
}

public class PlayerHealth : MonoBehaviour
{
    public float maxRedHealth = 10f;
    public float maxYellowHealth = 10f;
    public float maxGreenHealth = 10f;

     private float currentRedHealth;
     private float currentYellowHealth;
    private float currentGreenHealth;

    public float CurrentRedHealth => currentRedHealth;
    public float CurrentYellowHealth => currentYellowHealth;
    public float CurrentGreenHealth => currentGreenHealth;

    public UnityEvent OnRedHealthChanged;
    public UnityEvent OnYellowHealthChanged;
    public UnityEvent OnGreenHealthChanged;
    public UnityEvent OnDeath;

    public Action OnRedHeal;
    public Action OnGreenHeal;
    public Action OnYellowHeal;

    private void Awake()
    {
        currentRedHealth = maxRedHealth;
        currentYellowHealth = maxYellowHealth;
        currentGreenHealth = maxGreenHealth;

        OnRedHealthChanged?.Invoke();
        OnYellowHealthChanged?.Invoke();
        OnGreenHealthChanged?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Heal(1f, HealthType.Red);
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            Heal(1f, HealthType.Yellow);
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Heal(1f, HealthType.Green);
        }
    }

    public void TakeDamage(float amount, HealthType type)
    {
        if (amount < 0) return;

        DamageVignette.getInstance().DamageTaken();
        DamageVignette.getInstance().Shake.StartShake();

        switch (type)
        {
            case HealthType.Red:
                currentRedHealth = Mathf.Clamp(currentRedHealth - amount, 0, maxRedHealth);
                OnRedHealthChanged?.Invoke();
                break;
            case HealthType.Yellow:
                currentYellowHealth = Mathf.Clamp(currentYellowHealth - amount, 0, maxYellowHealth);
                OnYellowHealthChanged?.Invoke();
                break;
            case HealthType.Green:
                currentGreenHealth = Mathf.Clamp(currentGreenHealth - amount, 0, maxGreenHealth);
                OnGreenHealthChanged?.Invoke();
                break;
        }
        CheckForDeath();
    }

    public void Heal(float amount)
    {
        Heal(amount, HealthType.Red);
        Heal(amount, HealthType.Yellow);
        Heal(amount, HealthType.Green);
    }

    public void Heal(float amount, HealthType type)
    {
        if (amount < 0) return;

        switch (type)
        {
            case HealthType.Red:
                currentRedHealth = Mathf.Clamp(currentRedHealth + amount, 0, maxRedHealth);
                OnRedHealthChanged?.Invoke();
                OnRedHeal?.Invoke();
                break;
            case HealthType.Yellow:
                currentYellowHealth = Mathf.Clamp(currentYellowHealth + amount, 0, maxYellowHealth);
                OnYellowHealthChanged?.Invoke();
                OnYellowHeal?.Invoke();
                break;
            case HealthType.Green:
                currentGreenHealth = Mathf.Clamp(currentGreenHealth + amount, 0, maxGreenHealth);
                OnGreenHealthChanged?.Invoke();
                OnGreenHeal?.Invoke();
                break;
        }
    }

    private void CheckForDeath()
    {
        if (currentRedHealth <= 0 || currentYellowHealth <= 0 || currentGreenHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Debug.Log("Игрок умер.");
    }
}
