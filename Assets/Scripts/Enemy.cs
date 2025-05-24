using UnityEngine;

public class Enemy : GameEntity, IDamagable
{
    
    void OnMouseDown()
    {
               // Example of taking damage when the enemy is clicked
        TakeDamage(10);
    }   
}
