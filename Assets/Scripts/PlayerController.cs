using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerController : GameEntity , IDamagable
{
    public float laserCooldown = 0.25f; // Cooldown time between laser shots
    private float lastFireTime; // Time when the last laser was fired
    //Ability flags
    private bool isSpeedBoosted = false;
    private bool isDamageBoosted = false;
    //Ability Settings
    public int healthBoostAmount = 20; // Amount of health to restore when picking up a health boost
    public int maxBoostedHealth = 200; //Max amount of health to have boosted

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
        AudioManager.Instance.PlaySFX(AudioManager.Instance.takeDamage);
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
        PlayerPrefs.SetInt("FinalScore", GameManager.instance.enemiesDefeated);
        PlayerPrefs.Save();
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.loseSound);
        SceneManager.LoadScene("GameOverScene"); // Load the Game Over scene
    }
    
    public void ApplyHealthBoost()
    {
        if (currentHealth <= maxBoostedHealth)
        {
            currentHealth += healthBoostAmount;
            if (currentHealth > maxBoostedHealth)
            {
                currentHealth = maxBoostedHealth; // Ensure health does not exceed max boosted health
            }
            if (healthBar != null)
            {
                healthBar.SetHealth(currentHealth); // Update the health bar
            }
        }
    }
    public void ApplySpeedBoost(float speedMultiplier, float boostDuration)
    {
        if (!isSpeedBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine(speedMultiplier, boostDuration));
        }
    }
    private IEnumerator SpeedBoostCoroutine(float speedMultiplier,float boostDuration)
    {
        isSpeedBoosted = true;
        moveSpeed *= speedMultiplier; // Increase move speed
        yield return new WaitForSeconds(boostDuration); // Wait for the duration
        moveSpeed /= speedMultiplier; // Reset move speed
        isSpeedBoosted = false; // Reset the speed boost flag
    }
    public void ApplyDamageBoost(float damageMultiplier,float boostDuration)
    {
        if (!isDamageBoosted)
        {
            StartCoroutine(DamageBoostCoroutine(damageMultiplier,boostDuration));
        }
    }
    private IEnumerator DamageBoostCoroutine(float damgageMultiplier, float boostDuration)
    {
        isDamageBoosted = true;
        laserPrefab.GetComponent<Laser>().damage *= (int)damgageMultiplier; // Increase laser damage
        yield return new WaitForSeconds(boostDuration); // Wait for the duration
        laserPrefab.GetComponent<Laser>().damage /= (int)damgageMultiplier; // Reset laser damage
        isDamageBoosted = false; // Reset the damage boost flag
    }
}
