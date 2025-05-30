using UnityEngine;

public class HealthBoostAbility : PlayerAbility
{
    public int healthAmount = 20; // Amount of health to boost

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Activate(collision.gameObject); // Activate the health boost ability
            Destroy(gameObject); // Destroy the health boost object after activation
        }
    }
    void Update()
    {
        if (transform.position.y < -50f) // Check if the health boost has moved off-screen
        {
            Destroy(gameObject); 
        }
    }
    public override void Activate(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.ApplyHealthBoost(); // Call the method to increase health in PlayerController
        }
        Destroy(gameObject);
    }
}
