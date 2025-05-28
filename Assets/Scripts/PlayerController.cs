using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : GameEntity , IDamagable
{
    public float laserCooldown = 0.25f; // Cooldown time between laser shots
    private float lastFireTime; // Time when the last laser was fired

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
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= lastFireTime + laserCooldown)
        {
            FireLaser();
            lastFireTime = Time.time; // Update the last fire time
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
            laserScript.direction = Vector2.right; // Set the direction of the laser to left
            laserScript.targetTag = "Enemy"; // Set the target tag for the laser
        }
    }
    public override void die()
    {
        base.die(); // Call the base class die method
        SceneManager.LoadScene("GameOverScene"); // Load the Game Over scene
    }
    
}
