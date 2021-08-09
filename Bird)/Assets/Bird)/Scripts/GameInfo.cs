using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    [SerializeField]
    Text scoreValue;

    [SerializeField]
    Text moneyValue;

    [SerializeField]
    GameObject panelGameOver;

    [SerializeField]
    Text bestValue;

    [SerializeField]
    Text totalValue;

    private static int score;
    private static int money;

    void Update()
    {
        scoreValue.text = score.ToString();
        moneyValue.text = money.ToString();

        bestValue.text = PlayerPrefs.GetInt("Best").ToString();
        totalValue.text = PlayerPrefs.GetInt("Total").ToString();
        if(Time.timeScale == 0)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void OnRepeat()
    {
        Time.timeScale = 1;
        score = 0;
        money = 0;
        SceneManager.LoadScene(0);
    }
    
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }
}
