using UnityEngine;

public class Enemy : GameEntity, IDamagable
{
    private HealthBar healthBar;
    private Transform player;
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
    
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found in the scene.");
        }
    }
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Move(direction);
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
