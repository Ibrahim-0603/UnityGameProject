using UnityEngine;

public class FastEnemy : Enemy
{
    protected override void Start()
    {

        // Unique FastEnemy setup
        moveSpeed = 40f; // faster than regular enemy
        maxHealth = 50;
        base.Start();

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }

    public override void Move(Vector2 direction)
    {
        base.Move(direction); // uses standard movement for now
    }

}
