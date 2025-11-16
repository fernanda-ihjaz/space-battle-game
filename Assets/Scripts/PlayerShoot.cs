using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed;
    public float lifeTime = 2.5f; // Tempo de vida do tiro
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Define a velocidade do Rigidbody em linha reta
        rb.linearVelocity = transform.right * shootSpeed;
        
        // Congela a rotação para não girar
        rb.freezeRotation = true;
        
        // Destroi o tiro após alguns segundos para não ficar infinito
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Garante que o tiro não rotacione
        if (rb != null)
        {
            rb.angularVelocity = 0;
        }
    }
}
