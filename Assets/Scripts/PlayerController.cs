using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject shootPlayer;
    public Transform LocationOfTheShot;
    
    public float speed;

    public bool canShoot;

    private Vector2 movement;
    
    void Start()
    {
        canShoot = false;
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
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == false)
        {
            Instantiate(shootPlayer, LocationOfTheShot.position, LocationOfTheShot.rotation);
        }
    }
}
