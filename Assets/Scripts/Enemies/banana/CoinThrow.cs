using UnityEngine;
using System.Collections;

public class CoinThrow : MonoBehaviour
{
    public GameObject coinPrefab;
    public float minThrowForce;
    public float maxThrowForce;
    public float rotationSpeed;
    public Transform playerCamera;
    public float offsetRight;
    public float offsetLeft;
    public float delay;
    public float arcHeight;
    public float coinLifetime; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ThrowCoinWithDelay());
        }
    }

    IEnumerator ThrowCoinWithDelay()
    {
        yield return new WaitForSeconds(delay);

        float throwForce = Random.Range(minThrowForce, maxThrowForce);
        Vector3 spawnPosition = playerCamera.position + playerCamera.forward * 1f + playerCamera.right * offsetRight;
        GameObject coin = Instantiate(coinPrefab, spawnPosition, playerCamera.rotation);

        Rigidbody rb = coin.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 arcDirection = (playerCamera.forward + Vector3.up * (arcHeight / throwForce) - playerCamera.right * offsetLeft).normalized;
            rb.velocity = arcDirection * throwForce;
            rb.angularVelocity = Random.Range(0, 2) == 0
                ? new Vector3(rotationSpeed, 0, 0)
                : new Vector3(0, rotationSpeed, 0);
            rb.useGravity = true;
        }

        Destroy(coin, coinLifetime);
    }
}
