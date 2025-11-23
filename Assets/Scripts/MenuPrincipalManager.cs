using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private GameObject painelInitialMenu;
    [SerializeField] private GameObject painelOptions;

    public void Jogar()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void AbrirOpcoes()
    {
        painelInitialMenu.SetActive(false);
        painelOptions.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOptions.SetActive(false);    
        painelInitialMenu.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
}

