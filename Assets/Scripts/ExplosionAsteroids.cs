using UnityEngine;

public class ExplosionAsteroids: MonoBehaviour
{
    public float durationMultiplier = 1.5f; // Multiplica a duração da explosão
    
    void Start()
    {
        // Pega o Animator para saber a duração da animação
        Animator animator = GetComponent<Animator>();
        
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            // Pega a duração da primeira animação
            AnimationClip clip = animator.runtimeAnimatorController.animationClips[0];
            // Destroi após a animação terminar (com multiplicador)
            Destroy(gameObject, clip.length * durationMultiplier);
        }
        else
        {
            // Se não tiver animator, destroi após 0.5 segundos
            Destroy(gameObject, 0.5f * durationMultiplier);
        }
    }
}
