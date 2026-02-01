using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (gameManager != null)
        {
            gameManager.Collect();
        }

        Destroy(gameObject);
    }
}
