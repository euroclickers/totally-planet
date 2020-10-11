using System;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    public Card card;
    public ResourceManager resourceManager;
    public int seed = 0;
    public CanvasUI canvas;
    private Deck deck;
    private List<Card> createdCards;
    // Start is called before the first frame update
    void Start()
    {
        seed = (seed == 0) ? new System.Random().Next() : seed;
        canvas.UpdateSeedLabel(seed);

        deck = new Deck(seed);
        createdCards = new List<Card>();

        generate3Cards();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void NextTurn()
    {
        destoryCards();
        resourceManager.ResourceUpdate();
        checkEndGame();
        Debug.Log("----New turn----" + deck.Count);
        generate3Cards();
    }

    private void checkEndGame()
    {
        if(resourceManager.population <= 0)
        {
            Debug.Log("LOSEEER");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

    private void destoryCards()
    {
        foreach(var card in createdCards)
        {
            Destroy(card.gameObject);
        }

        createdCards = new List<Card>();
    }

    private void generate3Cards()
    {
        try
        {
            createdCards.Add(Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity).cloneProperties(deck.GetNextCard()));
            createdCards.Add(Instantiate(card, new Vector3(4, 0, 0), Quaternion.identity).cloneProperties(deck.GetNextCard()));
            createdCards.Add(Instantiate(card, new Vector3(-4, 0, 0), Quaternion.identity).cloneProperties(deck.GetNextCard()));
            canvas.UpdateRemainingCardsLabel(deck.Count);
        }catch(System.InvalidOperationException e)
        {
            Debug.Log(e.Message);
            Debug.Log("WINNER");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
