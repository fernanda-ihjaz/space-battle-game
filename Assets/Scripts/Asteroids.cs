using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public GameObject explosionPrefab; // Arraste o prefab da explosão aqui
    public float explosionScale = 1f; // Escala da explosão (1 = normal, 0.5 = pequeno, 2 = grande)
    public float rotationSpeed = 30f; // Velocidade de rotação em graus por segundo
    
    void Start()
    {
        // Adiciona a tag Asteroid se não tiver
        if (!gameObject.CompareTag("Asteroid"))
        {
            gameObject.tag = "Asteroid";
        }
    }
    
    void Update()
    {
        // Rotaciona o asteroide em seu próprio eixo Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com o jogador ou com um disparo
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Shoot"))
        {
            // Cria a explosão na posição do asteroide
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                // Ajusta a escala da explosão
                explosion.transform.localScale = Vector3.one * explosionScale;
            }
            
            // Destroi o disparo se acertou
            if (collision.gameObject.CompareTag("Shoot"))
            {
                Destroy(collision.gameObject);
            }
            
            // Destroi o asteroide
            Destroy(gameObject);
        }
    }
}
