using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 200f;
    public int damage = 40;
    public string targetTag; 
    public Vector2 direction = Vector2.right; // Default direction is right

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction *speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > 200f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag)||other.CompareTag("Meteor"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(damage);
            }
            Destroy(gameObject);        // Destroy the laser after it hits something

        }
    }
}
