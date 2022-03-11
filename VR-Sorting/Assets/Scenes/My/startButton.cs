using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public timer timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button()
    {
        menu.active = false;
        timer.stopTimer = false;
    }
}
