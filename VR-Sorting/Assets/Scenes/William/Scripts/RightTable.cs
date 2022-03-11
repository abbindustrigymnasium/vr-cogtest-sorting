using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTable : MonoBehaviour
{
    [Header("Corresponding Board Side")]
    [SerializeField] private GameObject boardSide;
    [Header("Placement Board")]
    [SerializeField] private Transform board;

    private List<GameObject> cards = new List<GameObject>() { null, null, null, null }; // Vi vill ha koll på vilket kort som finns var, och därför har vi koll på index
    private List<GameObject> clones = new List<GameObject>() { null, null, null, null };
    [HideInInspector] public List<Collider> misplaced = new List<Collider>() {null, null, null, null }; // För de kort som är felplacerade

    

    void placeClones()
    {
        //For loop för varje x och y värde
        int cloneIndex = 0;
        for (int z=0; z<2; z++)
        {
            for (int y=0; y<2; y++)
            {
                if (clones[cloneIndex] != null)
                {
                    GameObject clone = clones[cloneIndex];
                    float yPos = boardSide.transform.position.y - (1 / board.transform.localScale.y) + (2 / board.transform.localScale.y) * y;
                    float zPos = boardSide.GetComponent<Collider>().bounds.center.z - (2 / board.transform.localScale.z) + (4 / board.transform.localScale.z) * z;
                    clone.transform.position = new Vector3(boardSide.transform.position.x-1*board.transform.localScale.x, yPos, zPos);
                    cloneIndex++;
                }
            }
        }
    }

    void processClone(Collider other, int newIndex)
    {
        GameObject clone;
        clone = Instantiate(other, boardSide.transform).gameObject;
        Destroy(clone.GetComponent<Rigidbody>());
        clone.transform.localRotation = Quaternion.Euler(other.gameObject.transform.localRotation.x + 90f, 0, other.gameObject.transform.localRotation.z + 90f);
        clone.transform.localScale = new Vector3(other.gameObject.transform.localScale.x / (board.transform.localScale.z), other.gameObject.transform.localScale.y / (board.transform.localScale.x), other.gameObject.transform.localScale.z / (board.transform.localScale.y));
        clones[newIndex] = clone;
        this.placeClones();
    }

    // Korten måste "snappa" på plats, förbestämd eller programmerad?? Testar programmerad, om full ska byta plats!
    // -- Ny lösning: De snappar inte alls på plats; spelaren straffas för att ha försökt göra fel.

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "card")
        {
            var newIndex = cards.FindIndex(0, cards.Count, x => x == null);
            if (newIndex == -1)
            {
                misplaced[misplaced.FindIndex(0,misplaced.Count, x => x == null)] = other;
            }
            else
            {
                cards[newIndex] = other.gameObject;
                this.processClone(other, newIndex);
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "card")
        {
            if (misplaced.FindIndex(0, misplaced.Count, x => x != null) == -1) {
                var removeIndex = cards.FindIndex(0, cards.Count, x => x == other.gameObject);
                cards[removeIndex] = null;
                Destroy(clones[removeIndex]);
                clones[removeIndex] = null;

                this.placeClones();
        }
            else
            {
                var removeIndex = cards.FindIndex(0, cards.Count, x => x == other.gameObject);
                cards[removeIndex] = null;
                Debug.Log(removeIndex);
                Destroy(clones[removeIndex]);
                clones[removeIndex] = null;

                var misplacedIndex = misplaced.FindIndex(0, misplaced.Count, x => x != null);
                cards[removeIndex] = misplaced[misplacedIndex].gameObject;
                this.processClone(misplaced[misplacedIndex], removeIndex);
                misplaced[misplacedIndex] = null;
            }
        }
        
    }
}
