using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    static int player_score = 0;
    static int highScore = 0;
    Text textComponent;
    static public void AddPoint()
    {
        player_score++;
        if (player_score > highScore)
        {
            highScore = player_score;
        }
    }
    private void Start()
    {
        player_score = 0;
        textComponent = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("highScore", highScore);
    }
    // Update is called once per frame
    void Update()
    {
        textComponent.text= "Score: " + player_score + "\nHigh Score: " + highScore;
    }
}
