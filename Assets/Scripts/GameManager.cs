using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text currentScore;
    public Text finalScoreText;
    public Text highScoreText;

    //Menu Variables
    [SerializeField] private string gameScene, menuScene, gameOverScene;

    public int defeatedEnemies = 0;

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
        SceneManager.LoadScene(gameOverScene);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

}
