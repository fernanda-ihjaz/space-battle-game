using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
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
