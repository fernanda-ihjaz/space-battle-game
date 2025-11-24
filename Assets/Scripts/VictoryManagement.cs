using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public Text finalScoreText;

    public void Start()
    {
        int finalScore = GameManager.Instance.defeatedEnemies;

        finalScoreText.text = "PONTUAÇÃO: "+ finalScore;

    }
    public void RestartGame()
    {
        GameManager.Instance.ResetPlayer();
        GameManager.Instance.RestartGame();
    }

    public void GoToMenu()
    {
        GameManager.Instance.ResetPlayer();
        GameManager.Instance.LoadMenu();

    }
}
