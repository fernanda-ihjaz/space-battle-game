using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int minimumEnemiesToDefeat = GameManager.Instance.minimumEnemiesToDefeat;
            int defeatedEnemies = GameManager.Instance.defeatedEnemies;
            Debug.Log(minimumEnemiesToDefeat); //5
            Debug.Log(defeatedEnemies); //0
            
            if(defeatedEnemies < minimumEnemiesToDefeat)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                GameManager.Instance.Victory();   
            }

        }
    }
}
