using UnityEngine;
using UnityEngine.Events;

public enum HealthType
{
    Red,
    Orange,
    Yellow,
    Green
}

public class PlayerHealth : MonoBehaviour
{
    public float maxRedHealth = 10f;
    public float maxOrangeHealth = 10f;
    public float maxYellowHealth = 10f;
    public float maxGreenHealth = 10f;

     private float currentRedHealth;
     private float currentOrangeHealth;
     private float currentYellowHealth;
    private float currentGreenHealth;

    public float CurrentRedHealth => currentRedHealth;
    public float CurrentBlueHealth => currentOrangeHealth;
    public float CurrentYellowHealth => currentYellowHealth;
    public float CurrentGreenHealth => currentGreenHealth;

    public UnityEvent<float> OnRedHealthChanged;
    public UnityEvent<float> OnBlueHealthChanged;
    public UnityEvent<float> OnYellowHealthChanged;
    public UnityEvent<float> OnGreenHealthChanged;
    public UnityEvent OnDeath;

    private void Awake()
    {
        currentRedHealth = maxRedHealth;
        currentOrangeHealth = maxOrangeHealth;
        currentYellowHealth = maxYellowHealth;
        currentGreenHealth = maxGreenHealth;

        OnRedHealthChanged?.Invoke(currentRedHealth / maxRedHealth);
        OnBlueHealthChanged?.Invoke(currentOrangeHealth / maxOrangeHealth);
        OnYellowHealthChanged?.Invoke(currentYellowHealth / maxYellowHealth);
        OnGreenHealthChanged?.Invoke(currentGreenHealth / maxGreenHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(1f, HealthType.Red);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f, HealthType.Orange);
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            TakeDamage(1f, HealthType.Yellow);
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            TakeDamage(1f, HealthType.Green);
        }
    }

    public void TakeDamage(float amount, HealthType type)
    {
        if (amount < 0) return;

        switch (type)
        {
            case HealthType.Red:
                currentRedHealth = Mathf.Clamp(currentRedHealth - amount, 0, maxRedHealth);
                OnRedHealthChanged?.Invoke(currentRedHealth / maxRedHealth);
                break;
            case HealthType.Orange:
                currentOrangeHealth = Mathf.Clamp(currentOrangeHealth - amount, 0, maxOrangeHealth);
                OnBlueHealthChanged?.Invoke(currentOrangeHealth / maxOrangeHealth);
                break;
            case HealthType.Yellow:
                currentYellowHealth = Mathf.Clamp(currentYellowHealth - amount, 0, maxYellowHealth);
                OnYellowHealthChanged?.Invoke(currentYellowHealth / maxYellowHealth);
                break;
            case HealthType.Green:
                currentGreenHealth = Mathf.Clamp(currentGreenHealth - amount, 0, maxGreenHealth);
                OnGreenHealthChanged?.Invoke(currentGreenHealth / maxGreenHealth);
                break;
        }
        CheckForDeath();
    }

    public void Heal(float amount)
    {
        Heal(amount, HealthType.Red);
        Heal(amount, HealthType.Yellow);
        Heal(amount, HealthType.Green);
        Heal(amount, HealthType.Orange);
    }

    public void Heal(float amount, HealthType type)
    {
        if (amount < 0) return;

        switch (type)
        {
            case HealthType.Red:
                currentRedHealth = Mathf.Clamp(currentRedHealth + amount, 0, maxRedHealth);
                OnRedHealthChanged?.Invoke(currentRedHealth / maxRedHealth);
                break;
            case HealthType.Orange:
                currentOrangeHealth = Mathf.Clamp(currentOrangeHealth + amount, 0, maxOrangeHealth);
                OnBlueHealthChanged?.Invoke(currentOrangeHealth / maxOrangeHealth);
                break;
            case HealthType.Yellow:
                currentYellowHealth = Mathf.Clamp(currentYellowHealth + amount, 0, maxYellowHealth);
                OnYellowHealthChanged?.Invoke(currentYellowHealth / maxYellowHealth);
                break;
            case HealthType.Green:
                currentGreenHealth = Mathf.Clamp(currentGreenHealth + amount, 0, maxGreenHealth);
                OnGreenHealthChanged?.Invoke(currentGreenHealth / maxGreenHealth);
                break;
        }
    }

    private void CheckForDeath()
    {
        if (currentRedHealth <= 0 || currentOrangeHealth <= 0 || currentYellowHealth <= 0 || currentGreenHealth <= 0)
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
