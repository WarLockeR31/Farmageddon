using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    public UnityEvent OnRedHeal;
    public UnityEvent OnGreenHeal;
    public UnityEvent OnYellowHeal;
    public UnityEvent OnRedHealthChanged;
    public UnityEvent OnYellowHealthChanged;
    public UnityEvent OnGreenHealthChanged;
    public UnityEvent OnDeath;

    public GameObject deathMenuUI;

    private bool isDead = false;

    public bool IsDead => isDead;

    private void Awake()
    {
        currentRedHealth = maxRedHealth;
        currentYellowHealth = maxYellowHealth;
        currentGreenHealth = maxGreenHealth;

        OnRedHealthChanged?.Invoke();
        OnYellowHealthChanged?.Invoke();
        OnGreenHealthChanged?.Invoke();

        if (deathMenuUI != null)
            deathMenuUI.SetActive(false);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    Heal(1f, HealthType.Red);
        //}
        //if (Input.GetKeyDown(KeyCode.LeftBracket))
        //{
        //    Heal(1f, HealthType.Yellow);
        //}
        //if (Input.GetKeyDown(KeyCode.RightBracket))
        //{
        //    Heal(1f, HealthType.Green);
        //}
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
        if (isDead) return;

        isDead = true;
        OnDeath?.Invoke();
        ShowDeathMenu();
    }

    public void ShowDeathMenu()
    {
        if (deathMenuUI != null)
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
            SetCursorVisible(true);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void SetCursorVisible(bool visible)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}
