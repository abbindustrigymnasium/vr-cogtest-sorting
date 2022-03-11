using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer2 : MonoBehaviour
{
    //public Slider timerSlider;

    public TextMesh timerText;
    public float time = 120f;

    public bool stopTimer = true;



    void Start()
    {

    }

    void Update()
    {
        if (!stopTimer)
        {
            time -= Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(time / 60);

        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)

        {

            stopTimer = true;
            EventManager.RaiseOnFinishedGame();

        }

        if (stopTimer == false)

        {

            timerText.text = textTime;

            //timerSlider.value = time;

        }
    }
}
