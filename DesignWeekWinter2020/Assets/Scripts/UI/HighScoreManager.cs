using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager hsManager;
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("1stScore"))
        {
            CreateFakeRankings();
        }

        if (hsManager == null)
        {
            hsManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public bool CheckHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("5thScore"))
        {
            return true;
        }

        return false;
    }

    public static void AddHighScore(int newScore, string newName)
    {
        if (newScore >= PlayerPrefs.GetInt("1stScore"))
        {
            PlayerPrefs.SetInt("5thScore", PlayerPrefs.GetInt("4thScore"));
            PlayerPrefs.SetInt("4thScore", PlayerPrefs.GetInt("3rdScore"));
            PlayerPrefs.SetInt("3rdScore", PlayerPrefs.GetInt("2ndScore"));
            PlayerPrefs.SetInt("2ndScore", PlayerPrefs.GetInt("1stScore"));
            PlayerPrefs.SetInt("1stScore", newScore);

            PlayerPrefs.SetString("5thName", PlayerPrefs.GetString("4thName"));
            PlayerPrefs.SetString("4thName", PlayerPrefs.GetString("3rdName"));
            PlayerPrefs.SetString("3rdName", PlayerPrefs.GetString("2ndName"));
            PlayerPrefs.SetString("2ndName", PlayerPrefs.GetString("1stName"));
            PlayerPrefs.SetString("1stName", newName);
        }
        else if (newScore >= PlayerPrefs.GetInt("2ndScore"))
        {
            PlayerPrefs.SetInt("5thScore", PlayerPrefs.GetInt("4thScore"));
            PlayerPrefs.SetInt("4thScore", PlayerPrefs.GetInt("3rdScore"));
            PlayerPrefs.SetInt("3rdScore", PlayerPrefs.GetInt("2ndScore"));
            PlayerPrefs.SetInt("2ndScore", newScore);

            PlayerPrefs.SetString("5thName", PlayerPrefs.GetString("4thName"));
            PlayerPrefs.SetString("4thName", PlayerPrefs.GetString("3rdName"));
            PlayerPrefs.SetString("3rdName", PlayerPrefs.GetString("2ndName"));
            PlayerPrefs.SetString("2ndName", newName);
        }
        else if (newScore >= PlayerPrefs.GetInt("3rdScore"))
        {
            PlayerPrefs.SetInt("5thScore", PlayerPrefs.GetInt("4thScore"));
            PlayerPrefs.SetInt("4thScore", PlayerPrefs.GetInt("3rdScore"));
            PlayerPrefs.SetInt("3rdScore", newScore);

            PlayerPrefs.SetString("5thName", PlayerPrefs.GetString("4thName"));
            PlayerPrefs.SetString("4thName", PlayerPrefs.GetString("3rdName"));
            PlayerPrefs.SetString("3rdName", newName);
        }
        else if (newScore >= PlayerPrefs.GetInt("4thScore"))
        {
            PlayerPrefs.SetInt("5thScore", PlayerPrefs.GetInt("4thScore"));
            PlayerPrefs.SetInt("4thScore", newScore);

            PlayerPrefs.SetString("5thName", PlayerPrefs.GetString("4thName"));
            PlayerPrefs.SetString("4thName", newName);
        }
        else if (newScore >= PlayerPrefs.GetInt("5thScore"))
        {
            PlayerPrefs.SetInt("5thScore", newScore);
            PlayerPrefs.SetString("5thName", newName);
        }
        PlayerPrefs.Save();
    }
    void CreateFakeRankings()
    {
        PlayerPrefs.SetInt("1stScore", 2000);
        PlayerPrefs.SetInt("2ndScore", 1500);
        PlayerPrefs.SetInt("3rdScore", 1000);
        PlayerPrefs.SetInt("4thScore", 750);
        PlayerPrefs.SetInt("5thScore", 500);

        PlayerPrefs.SetString("1stName", "AAA");
        PlayerPrefs.SetString("2ndName", "SMG");
        PlayerPrefs.SetString("3rdName", "DAV");
        PlayerPrefs.SetString("4thName", "ASS");
        PlayerPrefs.SetString("5thName", "BUT");
        PlayerPrefs.Save();
    }
}
