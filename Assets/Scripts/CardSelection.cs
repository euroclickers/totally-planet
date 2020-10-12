using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelection : MonoBehaviour
{
    public Card card;
    private Deck deck;
    private List<Card> createdCards;
    public int seed;
    // Start is called before the first frame update
    void Start()
    {
        deck = new Deck(seed);
        createdCards = new List<Card>();

        generate3Cards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generate3Cards()
    {
        var cardSelection = GameObject.Find("CardSelection");
        try
        {
            var card1 = Instantiate(card, new Vector3(-5, -2, 0), Quaternion.identity).cloneProperties(deck.GetNextCard());
            card1.transform.parent = cardSelection.transform;
            card1.transform.name = "Card1";
            createdCards.Add(card1);

            var card2 = Instantiate(card, new Vector3(0, -2, 0), Quaternion.identity).cloneProperties(deck.GetNextCard());
            card2.transform.parent = cardSelection.transform;
            createdCards.Add(card2);
            card2.transform.name = "Card2";

            var card3 = Instantiate(card, new Vector3(5, -2, 0), Quaternion.identity).cloneProperties(deck.GetNextCard());
            card3.transform.parent = cardSelection.transform;
            createdCards.Add(card3);
            card3.transform.name = "Card3";

            //canvas.UpdateRemainingCardsLabel(deck.Count);
        }
        catch (System.InvalidOperationException e)
        {
            GameObject.Find("Parent").BroadcastMessage("OnCardSelectionOutOfCards", SendMessageOptions.DontRequireReceiver);
            
        }
    }

    public void OnCardSelected(Card card)
    {
        foreach (var createdCard in createdCards)
        {
            if (createdCard != card)
            {
                Destroy(createdCard.gameObject);
            }
        }
        createdCards = new List<Card>();
        createdCards.Add(card);
    }

    public void OnCardSelectFinished()
    {
        foreach (var createdCard in createdCards)
        {
            if (createdCard != card)
            {
                Destroy(createdCard.gameObject);
            }
        }
        createdCards = new List<Card>();
        GameObject.Find("Parent").BroadcastMessage("OnCardSelectionCardSelectedFinished", SendMessageOptions.DontRequireReceiver);
    }

    public void OnGameDirectorNewTurnStarted()
    {
        generate3Cards();
    }
}
