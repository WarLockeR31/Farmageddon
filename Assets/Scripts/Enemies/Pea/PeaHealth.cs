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
        Debug.Log($"���� ������� {amount} �����. ������� ��������: {CurrentHealth}");

        if (CurrentHealth <= 0)
        {
            Debug.Log("���� ����.");
            peaScript.Die(); // �������� ����� ������
        }
    }
}
