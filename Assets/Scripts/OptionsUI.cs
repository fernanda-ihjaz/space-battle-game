using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    // public InputField playerNameInput;
    public Dropdown difficultyDropdown;

    public void Start()
    {

        // Dificuldade (0 = Fácil, 1 = Médio, 2 = Difícil)
        int diff = difficultyDropdown.value + 1;
        GameManager.Instance.SetDifficulty(diff);
    }

    public void Update()
    {
        // Nome
        // string name = playerNameInput.text;
        // if (name.Trim().Length == 0)
        //     name = "Player";

        // GameManager.Instance.SetPlayerName(name);

        // Dificuldade (0 = Fácil, 1 = Médio, 2 = Difícil)
        int diff = difficultyDropdown.value + 1;
        GameManager.Instance.SetDifficulty(diff);
    }

}
