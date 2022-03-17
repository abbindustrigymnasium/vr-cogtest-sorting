using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wstartButton : MonoBehaviour
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
        SceneManager.LoadScene("william-room", LoadSceneMode.Single);
    }
}
