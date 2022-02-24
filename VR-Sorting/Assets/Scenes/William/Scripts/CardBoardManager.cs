using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoardManager : MonoBehaviour
{
    [Header("GameObjects:")]
    [SerializeField] private GameObject tableLeft;
    [SerializeField] private GameObject tableRight;
    [SerializeField] private GameObject board;

    // Parent - child
    // Clone GameObject to board segment.
    private GameObject boardDivider;
    private float boardHalfWidth;
    private float dividerWidth;
    private float leftHalfX;

    // Start is called before the first frame update
    void Start()
    {
        boardDivider = board.transform.GetChild(0).gameObject;
        dividerWidth = boardDivider.transform.localScale.x;
        boardHalfWidth = (board.transform.localScale.x - dividerWidth) / 2;
        leftHalfX = -(board.transform.position.x - board.transform.localScale.x) / 4;
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "card")
        {
            GameObject clone;
            clone = Instantiate(other, board.transform).gameObject;
            clone.transform.position = new Vector3(leftHalfX, clone.transform.position.y, clone.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 