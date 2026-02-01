using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;

    private Transform player;
    private Mask playerMask;
    private Rigidbody rb;
    private GameManager gameManager;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            playerMask = playerObj.GetComponent<Mask>();
        }

        rb = GetComponent<Rigidbody>();

        // Find GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // If mask is active, stop chasing
        if (playerMask != null && playerMask.IsMaskActive)
            return;

        Vector3 direction = (player.position - transform.position).normalized;

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            rotationSpeed * Time.fixedDeltaTime
        );
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Trigger Game Over
            if (gameManager != null)
            {
                gameManager.WinGame(); // reuse the panel logic
            }
        }
    }
}
