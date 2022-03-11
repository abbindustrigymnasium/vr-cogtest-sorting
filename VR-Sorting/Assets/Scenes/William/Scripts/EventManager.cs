using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnFinishedRound();
    public static event OnFinishedRound onFinishedRound;

    public static void RaiseOnFinishedRound()
    {
        if (onFinishedRound != null) onFinishedRound();
    }
}
