using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject shootPlayer;
    public Transform LocationOfTheShot;
    public Slider healthBar;

    public float speed = 7f;
    public float rotationSpeed = 150f; // Velocidade de rotação da nave
    public float boostMultiplier = 2f; // Multiplicador do boost
    public float boostDuration = 3f; // Duração do boost em segundos
    public float boostCooldown = 15f; // Tempo de recarga do boost
    
    public bool canShoot;
    
    private bool isBoosting = false;
    private bool canBoost = true;
    private float boostTimer = 0f;
    
    [Header("Sistema de Dano")]
    public int health = 3;
    public int maxHealth = 3;
    public float invincibilityDuration = 2f; // Duração da invencibilidade
    public float blinkInterval = 0.1f; // Intervalo entre piscadas
    
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    public static event System.Action OnPlayerDied;

    void Start()
    {
        canShoot = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    void Update()
    {
        MovementPlayer();
        Shoot();
        UpdateBoost();
    }

    private void MovementPlayer()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -rotationInput * rotationSpeed * Time.deltaTime);

        float moveInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = transform.right * moveInput;

        float currentSpeed = isBoosting ? speed * boostMultiplier : speed;

        oRigidbody2D.linearVelocity = moveDirection * currentSpeed;
    }
    
    private void UpdateBoost()
    {
        // Ativa o boost ao pressionar espaço (se disponível)
        if (Input.GetKeyDown(KeyCode.Space) && canBoost)
        {
            isBoosting = true;
            canBoost = false;
            boostTimer = boostDuration;
        }
        
        // Gerencia o timer do boost
        if (isBoosting)
        {
            boostTimer -= Time.deltaTime;
            
            if (boostTimer <= 0)
            {
                isBoosting = false;
                boostTimer = boostCooldown;
            }
        }
        // Cooldown para poder usar boost novamente
        else if (!canBoost)
        {
            boostTimer -= Time.deltaTime;
            
            if (boostTimer <= 0)
            {
                canBoost = true;
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == false)
        {
            Instantiate(shootPlayer, LocationOfTheShot.position, LocationOfTheShot.rotation);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com um asteroide e não está invencível
        if (collision.gameObject.CompareTag("Asteroid") && !isInvincible)
        {
            TakeDamage();
        }
    }
    
    public void TakeDamage()
    {
        health--;
        Debug.Log("Vida restante: " + health);
        
        healthBar.value = health;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    public void HurtPlayer(int damage)
    {
        // Usa o mesmo sistema de dano já existente
        for (int i = 0; i < damage; i++)
            TakeDamage();
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        
        // Desabilita colisão com asteroides (layer 6 = Asteroid, layer 7 = Player)
        Physics2D.IgnoreLayerCollision(6, 7, true);
        
        float elapsedTime = 0f;
        
        // Piscar durante o período de invencibilidade
        while (elapsedTime < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        
        // Garantir que o sprite esteja visível no final
        spriteRenderer.enabled = true;
        
        // Reabilita colisão com asteroides
        Physics2D.IgnoreLayerCollision(6, 7, false);
        
        isInvincible = false;
    }
    
    private void Die()
    {
        Debug.Log("Game Over!");
        OnPlayerDied?.Invoke();
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}
