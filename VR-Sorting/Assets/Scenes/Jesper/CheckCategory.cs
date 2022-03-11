using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using System.Linq;

public class Card
{
    
    public string Colour;
    public string Pattern;
    public int Amount;
    public string Shape;
    public string Sides;
    public string EdgePattern;
    public string EdgeColour;

    public Card()
    {
        Colour = "none";
        Pattern = "none";
        Amount = 0;
        Shape = "none";
        Sides = "none";
        EdgePattern = "none";
        EdgeColour = "none";
    }

    public Card (string colour, string pattern, int amount, string shape, string sides, string edgepattern, string edgecolour)
    {
        Colour = colour;
        Pattern = pattern;
        Amount = amount;
        Shape = shape;
        Sides = sides;
        EdgePattern = edgepattern;
        EdgeColour = edgecolour;
    }
}

public class CheckCategory : MonoBehaviour
{   
    public System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        var newCard = new Card("Blue", "Stripes", 3, "Square", "Blue", "Stripes", "Green");
        Card[] CardList = new Card[8];
        List<List<int>> NumberList = new List<List<int>>();

        for (int i = 0; i < 8; i++) 
            {
                CardList[i] = new Card();
            }

        for (int i = 0; i < 7; i++) 
            {
                var newNumList = new List<int>();
                while ((newNumList.Count != newNumList.Distinct().Count()) || (newNumList.Count == 0))
                {
                    newNumList.Clear();
                    for (int j = 0; j < 4; j++) {
                        newNumList.Add(rnd.Next(8));
                    }
                
                }
                NumberList.Add(newNumList);
            }

        for (int i = 0; i < 7; i++) 
        {
            var tempList = NumberList[i];
            string message = "category " + i + ": " + tempList[0] + tempList[1] + tempList[2] + tempList[3];
            Debug.Log(message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateCards()
    {

    }

    void CheckCategories()
    {

    }
}
