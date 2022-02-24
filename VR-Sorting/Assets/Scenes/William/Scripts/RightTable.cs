using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTable : MonoBehaviour
{
    [Header("Corresponding Board Side")]
    [SerializeField] private GameObject boardSide;
    [Header("Placement Board")]
    [SerializeField] private Transform board;
    [Header("Other table (other group)")]
    [SerializeField] private GameObject otherBoard;

    private List<GameObject> cards = new List<GameObject>() { null, null, null, null }; // Vi vill ha koll på vilket kort som finns var, och därför har vi koll på index
    private List<GameObject> clones = new List<GameObject>() { null, null, null, null };

    

    void placeClones()
    {
        clones.ForEach(delegate (GameObject clone)
        {
            if (clone != null)
            {
                int cloneAdjust = 0;
                int cloneIndex = clones.FindIndex(0, clones.Count, c => c == clone);
                cloneAdjust = cloneIndex % 2 == 0 ? cloneAdjust++ : cloneAdjust // Funkar detta????
                float yPos = boardSide.transform.position.y - (1 / board.transform.localScale.y) + (2 / board.transform.localScale.y) * ((cloneIndex) % 2);
                float zPos = boardSide.GetComponent<Collider>().bounds.center.z + (1 / board.transform.localScale.z) + (4 / board.transform.localScale.z) * cloneAdjust;
            clone.transform.position = new Vector3(boardSide.transform.position.x, yPos, zPos);
            }
        });
    }

    // Korten måste "snappa" på plats, förbestämd eller programmerad?? Testar programmerad, om full ska byta plats!

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "card")
        {
            var newIndex = cards.FindIndex(0, cards.Count, x => x == null);
            cards[newIndex] = other.gameObject;
            GameObject clone;
            clone = Instantiate(other, boardSide.transform).gameObject;
            clone.transform.localScale = new Vector3(1 / (board.transform.localScale.x * 2), 1 / (board.transform.localScale.y * 2), 1 / (board.transform.localScale.z * 2));
            Destroy(clone.GetComponent<Rigidbody>());
            clones[newIndex] = clone;
            this.placeClones();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "card")
        {
            if (cards.Count == 1)
            {
                cards[0] = null;
                Destroy(clones[0]);
                clones[0] = null;
            }
            else
            {
                var removeIndex = cards.FindIndex(0, cards.Count, x => x == other.gameObject);
                cards[removeIndex] = null;
                Destroy(clones[removeIndex]);
                clones[removeIndex] = null;
            }

            this.placeClones();
        }
        
    }
}
