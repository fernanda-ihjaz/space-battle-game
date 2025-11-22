using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização
    public Vector3 offset = new Vector3(0, 0, -10); // Offset da câmera (mantenha Z negativo para 2D)

    void LateUpdate()
    {
        if (target == null)
            return;

        // Posição desejada da câmera
        Vector3 desiredPosition = target.position + offset;
        
        // Suavizar o movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Aplicar a nova posição
        transform.position = smoothedPosition;
    }
}
