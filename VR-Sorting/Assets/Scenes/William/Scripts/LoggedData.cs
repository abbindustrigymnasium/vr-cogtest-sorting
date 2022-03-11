/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggedData : MonoBehaviour
{
    public static int errors = 0;
    public static GameObject[,] sorted = new GameObject[2, 4] { { null, null, null, null }, { null, null, null, null } };
    public static Collider[,] misplaced = new Collider[2, 4] { { null, null, null, null }, { null, null, null, null } };
    public static int correct = 0;

    void OnEnable()
    {
        EventManager.onFinishedRound += FinishRound;
    }

    private (int, int) findIndexErrors(GameObject[,] sorted)
    {
        IFound = -1;
        JFound = -1;

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (sorted[i,j] != null)
                {
                    IFound = i;
                    JFound = j;
                    break;
                }
            }
        }
        return (IFound, JFound);
    }

    void FinishRound()
    {
        if (RightTable.misplaced.FindIndex()) errors++;
        else
        {
            Debug.Log("All 4 cards ");
        }
    }
}
*/