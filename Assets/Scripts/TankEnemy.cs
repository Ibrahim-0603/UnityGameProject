using UnityEngine;

public class TankEnemy : Enemy
{
    protected override void Start()
    {

        // Unique TankEnemy setup
        moveSpeed = 5f; // slow
        maxHealth = 200;
        base.Start();

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }

    public override void Move(Vector2 direction)
    {
        base.Move(direction); // standard pathing for now
    }
}
