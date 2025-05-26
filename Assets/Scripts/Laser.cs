using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 200f;
    public int damage = 40;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right *speed * Time.deltaTime);
        if (transform.position.x > 200f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(damage);
            }
        }
        Destroy(gameObject);        // Destroy the laser after it hits something
    }
}
