using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text scoreText;

    public int scoreValue { get; set; }

    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        scoreText.text = scoreValue.ToString();
    }
}
