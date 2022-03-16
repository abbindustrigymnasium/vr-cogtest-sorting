using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wstartButton : MonoBehaviour
{
    public GameObject menu;
    public wtimer timer;

    public void button()
    {
        Debug.Log("Button");
        menu.active = false;
        timer.stopTimer = false;
    }
}
