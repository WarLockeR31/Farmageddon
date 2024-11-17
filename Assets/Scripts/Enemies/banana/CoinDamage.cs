using UnityEngine;

public class CoinDamage : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Banana"))
        {
            bananaScript bananaScr = other.GetComponent<bananaScript>();
            if (!bananaScr.CoinHit.isPlaying)
                bananaScr.CoinHit.Play();

            Debug.Log($"Нанесено {damageAmount} урона {other.name}.");

            other.GetComponent<Animator>().SetTrigger("boom");

            Destroy(gameObject);
        }
    }
}
