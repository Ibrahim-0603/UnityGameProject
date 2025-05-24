using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameEntity))]
public class abilitiesofplayer : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;

    [Header("Health Settings")]
    [SerializeField] private int healthBoost = 20;

    [Header("Ability Bar Settings")]
    [SerializeField] private SpriteRenderer abilityBar;
    [SerializeField] private Vector2 moveRange = new Vector2(2f, 2f);
    [SerializeField] private float moveInterval = 3f;
    [SerializeField] private float moveSpeed = 1f;

    [Header("Map Boundaries")]
    [SerializeField] private Vector2 mapMinBounds = new Vector2(-5f, -5f);
    [SerializeField] private Vector2 mapMaxBounds = new Vector2(5f, 5f);

    private float originalSpeed;
    private bool isDashing = false;
    private GameEntity gameEntity;
    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        gameEntity = GetComponent<GameEntity>();

        if (gameEntity != null)
        {
            originalSpeed = gameEntity.moveSpeed;
        }
        else
        {
            Debug.LogError("GameEntity component missing!");
        }

        InitializeAbilityBar();
    }

    void InitializeAbilityBar()
    {
        if (abilityBar != null)
        {
            // Unparent the ability bar and start at random position
            abilityBar.transform.SetParent(null);
            SetNewRandomPosition();
        }
        else
        {
            Debug.LogError("Ability Bar not assigned!");
        }
    }

    void Update()
    {
        HandleAbilityBarMovement();
    }

    void HandleAbilityBarMovement()
    {
        if (abilityBar == null) return;

        // Move in world space, not relative to player
        abilityBar.transform.position = Vector3.Lerp(
            abilityBar.transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        timer += Time.deltaTime;
        if (timer >= moveInterval)
        {
            SetNewRandomPosition();
            timer = 0f;
        }
    }

    void SetNewRandomPosition()
    {
        // Stay within map boundaries
        float randomX = Mathf.Clamp(
            abilityBar.transform.position.x + Random.Range(-moveRange.x, moveRange.x),
            mapMinBounds.x,
            mapMaxBounds.x
        );

        float randomY = Mathf.Clamp(
            abilityBar.transform.position.y + Random.Range(-moveRange.y, moveRange.y),
            mapMinBounds.y,
            mapMaxBounds.y
        );

        targetPosition = new Vector3(randomX, randomY, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUpBox"))
        {
            Destroy(other.gameObject);

            if (isDashing) return;

            if (Random.Range(0, 2) == 0)
            {
                ApplyHealthBoost();
            }
            else
            {
                StartCoroutine(Dash());
            }
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        gameEntity.moveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        gameEntity.moveSpeed = originalSpeed;
        isDashing = false;
    }

    void ApplyHealthBoost()
    {
        gameEntity.currentHealth = Mathf.Min(
            gameEntity.currentHealth + healthBoost,
            gameEntity.maxHealth
        );
    }
}