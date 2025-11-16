using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject shootPlayer;
    public Transform LocationOfTheShot;
    
    public float speed;
    public float tiltAngle = 20f;
    public float tiltSpeed = 5f;

    public bool canShoot;
    
    [Header("Sistema de Dano")]
    public int health = 3;
    public float invincibilityDuration = 2f; // Duração da invencibilidade
    public float blinkInterval = 0.1f; // Intervalo entre piscadas
    
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    
    void Start()
    {
        canShoot = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovementPlayer();
        Shoot();
    }

    private void MovementPlayer()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        oRigidbody2D.linearVelocity = movement * speed;
        
        float targetRotation = movement.y * tiltAngle;
        
        float currentZRotation = transform.rotation.eulerAngles.z;
        if (currentZRotation > 180) currentZRotation -= 360;
        
        float newRotation = Mathf.Lerp(currentZRotation, targetRotation, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0, 0, newRotation);
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
    
    private void TakeDamage()
    {
        health--;
        Debug.Log("Vida restante: " + health);
        
        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
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
        // Aqui você pode adicionar lógica de game over
        Destroy(gameObject);
    }
}
