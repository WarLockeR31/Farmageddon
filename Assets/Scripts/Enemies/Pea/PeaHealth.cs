using UnityEngine;

public class PeaHealth : Health
{
    private PeaScript peaScript;

    private void Start()
    {
        peaScript = GetComponent<PeaScript>();
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        Debug.Log($"Враг получил {amount} урона. Текущее здоровье: {CurrentHealth}");

        if (CurrentHealth <= 0)
        {
            Debug.Log("Враг умер.");
            peaScript.Die(); // Вызываем метод смерти
        }
    }
}
