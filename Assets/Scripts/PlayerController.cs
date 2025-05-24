using UnityEngine;

public class PlayerController : GameEntity , IDamagable
{
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(moveX, moveY).normalized;
        Move(direction);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Example of taking damage when the space key is pressed
            TakeDamage(10);
        }
    }
    
}
