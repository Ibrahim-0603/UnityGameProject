using UnityEngine;

public class PlayerController : GameEntity , IDamagable
{
    public GameObject laserPrefab; // Reference to the laser prefab
    public Transform firePoint; // Point from which the laser will be fired
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
    void FireLaser()
    {
        Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
    }
}
