using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnFinishedRound();
    public static event OnFinishedRound onFinishedRound;

    public delegate void OnFinishedGame();
    public static event OnFinishedGame onFinishedGame;

    public static void RaiseOnFinishedRound()
    {
        if (onFinishedRound != null) onFinishedRound();
    }

    public static void RaiseOnFinishedGame() 
    {
        if (onFinishedGame != null) onFinishedGame();
    }
    
}
