using UnityEngine;

public class DamageBoostAbility : PlayerAbility
{
    public float damgageMultiplier = 3f;
    public float boostDuration = 5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Activate(collision.gameObject); // Activate the damage boost ability
            Destroy(gameObject); // Destroy the damage boost object after activation
        }
    }
    void Update()
    {
        if (transform.position.y < -50f) // Check if the damage boost has moved off-screen
        {
            Destroy(gameObject);
        }
    }

    public override void Activate(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.ApplyDamageBoost(damgageMultiplier, boostDuration);
        }
        Destroy(gameObject);
    }
}
