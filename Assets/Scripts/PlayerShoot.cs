using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed;

    void Start()
    {
      
    }

    void Update()
    {
        MovementShoot();
    }

    private void MovementShoot()
    {
        transform.Translate(Vector3.right * shootSpeed * Time.deltaTime);
    }
}
