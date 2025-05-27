using UnityEngine;

public class Enemy : GameEntity, IDamagable
{
    private HealthBar healthBar;
    private Transform player;
    public float laserCooldown = 2f; // Cooldown time between laser shots
    private float timer;
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
        if (playerObject != null)
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
        //if (player != null)
        //{
        //    Vector2 direction1 = (player.position - transform.position).normalized;
        //    Move(direction1);
        //}
        timer += Time.deltaTime;
        if (timer >= laserCooldown)
        {
            FireLaser();
            timer = 0f; // Reset the timer after firing
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
    public override void FireLaser()
    { 
        base.FireLaser(); // Call the base class method to handle laser firing

        Laser laserScript = GetComponent<Laser>();
        if (laserScript != null)
        {
            laserScript.direction = Vector2.left; // Set the direction of the laser to left
            laserScript.targetTag = "Player"; // Set the target tag for the laser
        }
    }
    
}
