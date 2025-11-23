using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float shotSpeed;
    public float lifeTime;
    public int hurt;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        MoveShot();
    }

    void MoveShot()
    {
        transform.Translate(Vector3.right * shotSpeed * Time.deltaTime);
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