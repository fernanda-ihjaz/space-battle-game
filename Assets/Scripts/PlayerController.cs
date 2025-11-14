using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public float speed;
    private Vector2 movement;
    
    void Start()
    {
        
    }

    void Update()
    {
        MovementPlayer();
    }
    private void MovementPlayer()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        oRigidbody2D.linearVelocity = movement * speed;
    }
}
