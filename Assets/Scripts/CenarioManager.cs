using UnityEngine;
using UnityEngine.UI;
public class CenarioManager : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        scoreText.text = "INIMIGOS ABATIDOS: " + GameManager.Instance.defeatedEnemies + "/5";
    }
}
