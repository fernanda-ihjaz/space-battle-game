using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed;
    public float lifeTime = 2f; // Tempo de vida do tiro
    private Rigidbody2D rb;
    private Vector2 shootDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Captura a direção que a nave está apontando no momento do disparo
        shootDirection = transform.right;
        
        // Define a velocidade do tiro na direção da nave
        rb.linearVelocity = shootDirection * shootSpeed;
        
        // Congela a rotação para não girar
        rb.freezeRotation = true;
        
        // Destroi o tiro após alguns segundos para não ficar infinito
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Garante que o tiro não rotacione e mantenha a direção inicial
        if (rb != null)
        {
            rb.angularVelocity = 0;
            rb.linearVelocity = shootDirection * shootSpeed;
        }
    }

    // Detecta colisão do laser do jogador com inimigos
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.HurtEnemy(1); // Supondo que o tiro cause 1 ponto de dano
            }
            Destroy(gameObject); // Destroi o tiro ao colidir com o inimigo
        }
    }
}