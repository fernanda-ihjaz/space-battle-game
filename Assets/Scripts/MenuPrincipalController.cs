using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private GameObject painelInitialMenu, painelOptions, painelRanking, painelAbout;

    public void Jogar()
    {
        GameManager.Instance.LoadGame();
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

    public void AbrirRanking()
    {
        painelInitialMenu.SetActive(false);
        painelRanking.SetActive(true);
    }

    public void FecharRanking()
    {
        painelRanking.SetActive(false);    
        painelInitialMenu.SetActive(true);
    }
    public void AbrirAbout()
    {
        painelInitialMenu.SetActive(false);
        painelAbout.SetActive(true);
    }

    public void FecharAbout()
    {
        painelAbout.SetActive(false);    
        painelInitialMenu.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
}

