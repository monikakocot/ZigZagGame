﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;
    // Start is called before the first frame update

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore()
    {
        score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating("incementScore", 0.1f, 0.5f);   
    }

    public void StopScore()
    {
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }

        } else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
