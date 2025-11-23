using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int defeatedEnemies = 0;

    void Awake()
    {
        Instance = this;
    }

    public void IncreaseDefeatedEnemies()
    {
        defeatedEnemies++;
        Debug.Log("Inimigos abatidos: " + defeatedEnemies);
    }
}
