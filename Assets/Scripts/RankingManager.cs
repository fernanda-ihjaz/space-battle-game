using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class RankingEntry
{
    public string playerName;
    public int score;

    public RankingEntry(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}

public class RankingManager : MonoBehaviour
{
    public static List<RankingEntry> ranking = new List<RankingEntry>();
    private const int maxEntries = 5;

    void Awake()
    {
        LoadRanking();
    }

    public static void AddNewScore(string name, int score)
    {
        ranking.Add(new RankingEntry(name, score));

        ranking.Sort((a, b) => b.score.CompareTo(a.score));

        if (ranking.Count > maxEntries)
            ranking.RemoveRange(maxEntries, ranking.Count - maxEntries);

        SaveRanking();
    }

    public static void SaveRanking()
    {
        for (int i = 0; i < ranking.Count; i++)
        {
            PlayerPrefs.SetString("rank_name_" + i, ranking[i].playerName);
            PlayerPrefs.SetInt("rank_score_" + i, ranking[i].score);
        }

        PlayerPrefs.SetInt("rank_count", ranking.Count);
        PlayerPrefs.Save();
    }

    public static void LoadRanking()
    {
        ranking.Clear();

        int count = PlayerPrefs.GetInt("rank_count", 0);

        for (int i = 0; i < count; i++)
        {
            string name = PlayerPrefs.GetString("rank_name_" + i, "---");
            int score = PlayerPrefs.GetInt("rank_score_" + i, 0);

            ranking.Add(new RankingEntry(name, score));
        }
    }
}
