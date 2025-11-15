using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject shootPlayer;
    public Transform LocationOfTheShot;
    
    public float speed;
    public float tiltAngle = 20f;
    public float tiltSpeed = 5f;

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
}
