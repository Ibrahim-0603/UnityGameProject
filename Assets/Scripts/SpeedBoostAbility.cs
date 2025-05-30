using UnityEngine;

public class SpeedBoostAbility : PlayerAbility
{
    public float speedMultiplier = 2.5f;
    public float boostDuration = 5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Activate(collision.gameObject); // Activate the speed boost ability
            Destroy(gameObject); // Destroy the speed boost object after activation
        }
    }
    void Update()
    {
        if (transform.position.y < -50f) // Check if the speed boost has moved off-screen
        {
            Destroy(gameObject);
        }
    }

    public override void Activate(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.ApplySpeedBoost(speedMultiplier,boostDuration);
        }
        Destroy(gameObject);
    }
}
