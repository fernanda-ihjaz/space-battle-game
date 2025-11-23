using UnityEngine;
using UnityEngine.UI;

public class CenarioManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreText;
    public Text timerText;

    [Header("Timer")]
    public float tempoMaximo = 60f;
    private float tempoRestante;

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
        scoreText.text = "INIMIGOS ABATIDOS: " +
            GameManager.Instance.defeatedEnemies + "/5";
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
