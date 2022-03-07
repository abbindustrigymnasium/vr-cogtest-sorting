using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Slider timerSlider;

    public TextMesh timerText;

    public float gameTime;



    private bool stopTimer;



    void Start()

    {

        stopTimer = false;

        timerSlider.maxValue = gameTime;

        timerSlider.value = gameTime;



    }

    void Update()

    {

        float time = gameTime - Time.time;



        int minutes = Mathf.FloorToInt(time / 60);

        int seconds = Mathf.FloorToInt(time - minutes * 60f);



        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);



        if (time <= 0)

        {

            stopTimer = true;

        }



        if (stopTimer == false)

        {

            timerText.text = textTime;

            timerSlider.value = time;

        }

    }

}
