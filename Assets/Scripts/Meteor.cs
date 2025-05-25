using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int damage = 10; // Damage dealt by the meteor
    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable target = collision.GetComponent<IDamagable>();
        if (target != null)
        {
            target.TakeDamage(damage); // Deal damage to the target
            Destroy(gameObject); // Destroy the meteor after it hits something
        }
    }
    public float movespeed = 10f; // Speed of the meteor's movement
    void Update()
    {
        transform.Translate(Vector2.left * movespeed * Time.deltaTime); // Move the meteor to the left
        if(transform.position.x < -90f) // Check if the meteor has moved off-screen
        {
            Destroy(gameObject); // Destroy the meteor if it goes off-screen
        }
    }
}
