using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameEntity))]
public class AbilitiesOfPlayer : MonoBehaviour  // Changed to PascalCase
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

        if (gameEntity == null)
        {
            Debug.LogError("GameEntity component missing!");
            return;
        }

        originalSpeed = gameEntity.moveSpeed;
        InitializeAbilityBar();
    }

    void InitializeAbilityBar()
    {
        if (abilityBar == null)
        {
            Debug.LogError("Ability Bar not assigned!");
            return;
        }

        // Unparent and set initial random position
        abilityBar.transform.SetParent(null);
        SetNewRandomPosition();
    }

    void Update()
    {
        if (abilityBar != null)
        {
            HandleAbilityBarMovement();
        }
    }

    void HandleAbilityBarMovement()
    {
        // Move ability bar smoothly
        abilityBar.transform.position = Vector3.MoveTowards(
            abilityBar.transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // Update position at intervals
        timer += Time.deltaTime;
        if (timer >= moveInterval)
        {
            SetNewRandomPosition();
            timer = 0f;
        }
    }

    void SetNewRandomPosition()
    {
        // Calculate new position within bounds
        Vector3 currentPos = abilityBar.transform.position;

        float randomX = Mathf.Clamp(
            currentPos.x + Random.Range(-moveRange.x, moveRange.x),
            mapMinBounds.x,
            mapMaxBounds.x
        );

        float randomY = Mathf.Clamp(
            currentPos.y + Random.Range(-moveRange.y, moveRange.y),
            mapMinBounds.y,
            mapMaxBounds.y
        );

        targetPosition = new Vector3(randomX, randomY, currentPos.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PowerUpBox")) return;

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
        gameEntity.currentHealth = Mathf.Clamp(
            gameEntity.currentHealth + healthBoost,
            0,
            gameEntity.maxHealth
        );
    }
}