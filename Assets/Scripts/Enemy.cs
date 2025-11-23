using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyAttack;
    public Transform shootingLocation;
    private Transform playerTransform;
    private Camera mainCam;
    public float enemySpeed;
    public float maxFiringFrequency;
    public float currentFiringFrequency;
    public float chaseRange; // alcance da perseguição
    public float stoppingDistance; // distancia min entre player e enemy
    public float maxDistanceFromScreen;
    public bool armedEnemy;
    public bool chaseOnlyWhenClose;
    public bool followPlayer;
    public int maxLifeEnemy;
    public int currentLifeEnemy;

    private void OnEnable()
    {
        PlayerController.OnPlayerDied += DestroySelf;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= DestroySelf;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        currentLifeEnemy = maxLifeEnemy;

        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO != null)
            playerTransform = playerGO.transform;

        mainCam = Camera.main;

    }

    void Update()
    {
        MoveEnemy();

        if (armedEnemy == true)
        {
            TriggerAttack();
        }

        Vector3 screenPos = mainCam.WorldToViewportPoint(transform.position);

        // fora totalmente da tela e muito distante
        if (screenPos.x < -maxDistanceFromScreen ||
            screenPos.x > 1 + maxDistanceFromScreen ||
            screenPos.y < -maxDistanceFromScreen ||
            screenPos.y > 1 + maxDistanceFromScreen)
        {
            Destroy(gameObject);
        }

    }

    private void MoveEnemy()
    {
        if (!followPlayer)
        {
            transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
            return;
        }

        if (playerTransform == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) playerTransform = p.transform;
            else
            {
                transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
                return;
            }
        }

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (chaseOnlyWhenClose)
        {
            // Se estiver dentro do alcance, move em direção ao player; se não, anda para a esquerda
            if (distanceToPlayer <= chaseRange)
            {
                ChasePlayer(distanceToPlayer);
            }
            else
            {
                transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
            }
        }
        else
        {
            // Persegue sempre (ignorando chaseRange)
            ChasePlayer(distanceToPlayer);
        }

    }

    private void ChasePlayer(float distanceToPlayer)
    {
        if (distanceToPlayer > stoppingDistance)
        {
            // Move em direção ao player.
            // Use MoveTowards para movimento estável sem variações de física.
            Vector3 newPos = Vector3.MoveTowards(
                transform.position,
                playerTransform.position,
                enemySpeed * Time.deltaTime
            );

            transform.position = newPos;
        }
        else
        {
            // Opcional: quando estiver muito perto você pode atacar, ficar parado, etc.
            // Por enquanto, fica parado (ou você pode aplicar uma lógica de dano por contato).
        }
    }

    private void TriggerAttack()
    {
        currentFiringFrequency -= Time.deltaTime;
        if (currentFiringFrequency <= 0)
        {
            Instantiate(enemyAttack, shootingLocation.position, Quaternion.Euler(0f, 0f, 180f));
            currentFiringFrequency = maxFiringFrequency;
        }
    }

    public void HurtEnemy(int damage)
    {
        currentLifeEnemy -= damage;
        if (currentLifeEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.HurtPlayer(1);
            }

            Destroy(gameObject);
        }
    }

}