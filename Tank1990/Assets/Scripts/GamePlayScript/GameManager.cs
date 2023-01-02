using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    private float currentTime;
    public Text scoreText,timeCount;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score.ToString();
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeCount.text = "Time:"+time.Minutes.ToString()+":"+time.Seconds.ToString();
    }
}
