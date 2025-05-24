using UnityEngine;

public class PlayerController : GameEntity , IDamagable
{
    private HealthBar healthBar;
    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        else
        {
            Debug.LogError("HealthBar component not found in children of " + gameObject.name);
        }
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(moveX, moveY).normalized;
        Move(direction);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Example of taking damage when the space key is pressed
            TakeDamage(10);
        }
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        // Update the health bar if it exists
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }
}
