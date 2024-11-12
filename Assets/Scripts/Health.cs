using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = Mathf.Max(1, value);
            if (currentHealth > maxHealth)
            {
                CurrentHealth = maxHealth;
            }
            InvokeHealthChanged();
        }
    }

    private float currentHealth;

    public float CurrentHealth
    {
        get => currentHealth;
        protected set
        {
            float previousHealth = currentHealth;
            currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            if (currentHealth != previousHealth)
            {
                InvokeHealthChanged();
                if (currentHealth <= 0 && previousHealth > 0)
                {
                    Die();
                }
            }
        }
    }

    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnDeath;

    protected virtual void Awake()
    {
        currentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        if (amount < 0) return;
        CurrentHealth -= amount;
    }

    public virtual void Heal(float amount)
    {
        if (amount < 0) return;
        CurrentHealth += amount;
    }

    public bool IsAlive => currentHealth > 0;

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Debug.Log($"{gameObject.name} умер.");
    }

    private void InvokeHealthChanged()
    {
        if (MaxHealth > 0)
        {
            OnHealthChanged?.Invoke(CurrentHealth / MaxHealth);
        }
        else
        {
            OnHealthChanged?.Invoke(0);
        }
    }
}
