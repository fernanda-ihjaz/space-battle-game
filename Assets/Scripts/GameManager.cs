using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Menu Variables
    [SerializeField] private string gameScene, menuScene, gameOverScene;
    public string playerName = "Player 1";
    public int difficulty = 1;
    public int minimumEnemiesToDefeat = 5;
    public int defeatedEnemies = 0;
    public int currentScore = 0;


    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SetDifficulty(int level)
    {
        difficulty = level;
        if (difficulty == 1) minimumEnemiesToDefeat = 5;
        if (difficulty == 2) minimumEnemiesToDefeat = 10;
        if (difficulty == 3) minimumEnemiesToDefeat = 20;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseDefeatedEnemies()
    {
        defeatedEnemies++;
        Debug.Log("Inimigos abatidos: " + defeatedEnemies);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void GameOver()
    {
        RankingManager.AddNewScore(playerName, defeatedEnemies);
        SceneManager.LoadScene(gameOverScene);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void IncreaseScore(int points)
    {
        currentScore += points;
    }
    public void ResetPlayer()
    {
        currentScore = 0;
        defeatedEnemies = 0;
    }
}
