using UnityEngine;

public class Enemy : GameEntity, IDamagable
{
    private HealthBar healthBar;
    void Start()
    {
        // Initialize the health bar
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
    void OnMouseDown()
    {
               // Example of taking damage when the enemy is clicked
        TakeDamage(10);
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
