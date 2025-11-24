using UnityEngine;
using UnityEngine.UI;

public class RankingUI : MonoBehaviour
{
    public Text rankingText;

    void Start()
    {
        RankingManager.LoadRanking();

        rankingText.text = "";

        int pos = 1;
        foreach (var entry in RankingManager.ranking)
        {
            rankingText.text += pos + ". " + entry.playerName + " - " + entry.score + "\n";
            pos++;
        }
    }
}
