using UnityEngine;

public class GameEntity : MonoBehaviour
{
    // Public variables accessible to child classes
    public int maxHealth = 100;
    public int currentHealth;
    public string entityName;
    public float moveSpeed = 5f;
    
    protected Rigidbody2D rb;

    // Called once when the GameObject is created
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // This method can be overridden by subclasses to define custom movement
    public virtual void Move(Vector2 direction)
    {
        if (rb != null)
        {
            rb.linearVelocity = direction * moveSpeed;
        }
    }
    public virtual void die()
    {
               // Implement death logic here
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject); // Destroy the GameObject
    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " has " + currentHealth + " health left");
        
        if (currentHealth <= 0)
        {
            die();
        }
    }

    // For debugging or logging
    public virtual void PrintName()
    {
        Debug.Log("Entity name: " + entityName);
    }
}
