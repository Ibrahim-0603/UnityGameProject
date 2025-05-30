using UnityEngine;

public class Enemy : GameEntity, IDamagable
{
    protected HealthBar healthBar;
    private Transform player;
    public float laserCooldown = 2f; // Cooldown time between laser shots
    private float timer;
    private float stopXposition; // Position where the enemy stops moving
    private bool hasStopped = false;

    protected virtual void Start()
    {
        stopXposition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).x; 
        HealthDifficulty(); // Set health based on difficulty level

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
        if (player != null)
        {
            Vector2 direction1 = (player.position - transform.position).normalized;
            Move(direction1);
        }
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
        if (currentHealth <= 0)
        {
            GameManager gm = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
            if (gm != null)
            {
                gm.EnemiesDefeated();
            }
        }
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
    void HealthDifficulty()
    {
        if (DifficultyManager.Instance != null)
        {
            switch (DifficultyManager.Instance.CurrentDifficulty)
            {
                case DifficultyManager.DifficultyLevel.Easy:
                    maxHealth = maxHealth; // Easy difficulty health
                    laserCooldown = laserCooldown; // Easy difficulty laser cooldown
                    break;
                case DifficultyManager.DifficultyLevel.Medium:
                    maxHealth *= 2; // Medium difficulty health
                    laserCooldown /= 1.5f;
                    break;
                case DifficultyManager.DifficultyLevel.Hard:
                    maxHealth *= 3; // Hard difficulty health
                    laserCooldown /= 2f; // Hard difficulty laser cooldown
                    break;
                case DifficultyManager.DifficultyLevel.Insane:
                    maxHealth *= 4; // Insane difficulty health
                    laserCooldown /= 3f; // Insane difficulty laser cooldown
                    break;
                case DifficultyManager.DifficultyLevel.Endless:
                    maxHealth *= 2; // Endless mode health
                    laserCooldown /= 1.5f; // Endless mode laser cooldown
                    break;
            }
            currentHealth = maxHealth; // Set current health to max health
        }
    }
    public override void Move(Vector2 direction)
    {
        if (!hasStopped)
        {
            base.Move(direction);
            if (transform.position.x <= stopXposition)
            {
                hasStopped = true; // Stop moving when the enemy reaches the specified position
            }
        }
        else
        {
            Vector2 newVelocity = new Vector2(0, direction.y) * moveSpeed;
            GetComponent<Rigidbody2D>().linearVelocity = newVelocity; // Only allow vertical movement after stopping
        }

    }
    
}
