using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value = 1;    // how much this coin is worth

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(value);
            }

            Destroy(gameObject);  // remove the coin
        }
    }
}
