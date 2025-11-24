using UnityEngine;
using UnityEngine.UI;

public class CenarioManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreText;
    public Text timerText;

    [Header("Timer")]
    public float tempoMaximo = 90f;
    private float tempoRestante;
    int diff = GameManager.Instance.difficulty;

    private void Start()
    {
        tempoRestante = tempoMaximo;
    }

    private void Update()
    {
        AtualizarScore();
        AtualizarTimer();
    }

    private void AtualizarScore()
    {
        int minimumEnemiesToDefeat = GameManager.Instance.minimumEnemiesToDefeat;

        scoreText.text = "INIMIGOS ABATIDOS: " +
            GameManager.Instance.defeatedEnemies + "/"+ minimumEnemiesToDefeat;
    }

    private void AtualizarTimer()
    {
        tempoRestante -= Time.deltaTime;

        // Atualiza UI
        timerText.text = "TEMPO RESTANTE: "+ Mathf.Ceil(tempoRestante).ToString();

        // Acabou o tempo → Game Over
        if (tempoRestante <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public float GetTempoRestante()
    {
        return tempoRestante;
    }
}
