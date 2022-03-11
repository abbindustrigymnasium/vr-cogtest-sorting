using System.Collections;
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
        EventManager.onFinishedGame += FinishGame;
    }

    private (int row, int col) findIndexErrors(Collider[,] errors) //Hitta om det finns något felplacerat kort (t.ex 5 kort på samma bord, inte godkänt.)
    {
        int IFound = -1;
        int JFound = -1;

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (errors[i,j] != null)
                {
                    IFound = i;
                    JFound = j;
                    break;
                }
            }
        }
        return (row: IFound, col: JFound);
    }

    void FinishRound()
    {
        (int ErrorIndexRow, int ErrorIndexCol) = this.findIndexErrors(misplaced);

        if (ErrorIndexRow == -1) errors++; // Straffa spelaren om det finns ett felplacerat kort
        else
        {
            Debug.Log("All 4 cards ");
        }
    }
    void FinishGame()
    {
        // Lägg in all data där den ska vara!!!
        // Kolla upp hur man loggar datan!!!
    }
}
