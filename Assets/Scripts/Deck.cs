using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private Stack<Card> cards;

    public Deck(int seed)
    {
        Debug.Log("Start Deck");
        
        cards = loadCards();

        var rnd = new System.Random(seed);
        cards = new Stack<Card>(cards.OrderBy(a => rnd.Next()));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Card GetNextCard()
    {
        return cards.Pop();
    }

    public int Count {
        get  {
            if (cards != null && cards.Any())
                return cards.Count;
            return 0;
        }
    }

    private Stack<Card> loadCards()
    {

        /*


        Stack<Card> result = null;

        TextAsset cardsAsset = null;
        List<Card> cardList = null;

        try {
            
            Debug.Log("Cards loading from json init");

            result = new Stack<Card>();

            cardsAsset = Resources.Load("Text/cards") as TextAsset;
            cardList = JsonUtility.FromJson<List<Card>>(cardsAsset.text);

            foreach (var currentCard in cardList)
                result.Push(currentCard);

            Debug.Log(string.Format($"Finished: {result.Count} cards loaded"));
            Debug.Log("Cards loading from json ended");

        } 
        catch (Exception ex) {
            Debug.Log($"Error loading cards: {ex.Message}");
        }
        finally {
            cardsAsset = null;
            cardList = null;
        }

        return result;
        
        


        */
       


        var cards = new Stack<Card>();
        

        //TODO load from json
        cards.Push(new Card()
        {
            title = "Carta 1",
            effects = new List<Effect>() {
                new Effect()
                {
                    effectType = EffectType.POPULATION,
                    modifier = 0.8
                },
                new Effect()
                {
                    effectType = EffectType.NATURE,
                    modifier = 1.2
                }
            }
        });
        cards.Push(new Card()
        {
            title = "Carta 2",
            effects = new List<Effect>() {
                new Effect()
                {
                    effectType = EffectType.WATER,
                    modifier = 0.7
                },
                new Effect()
                {
                    effectType = EffectType.TEMPERATURE,
                    modifier = 1.5
                }
            }
        });
        cards.Push(new Card()
        {
            title = "Carta 3",
            effects = new List<Effect>() {
                new Effect()
                {
                    effectType = EffectType.WATER,
                    modifier = 1.5
                },
                new Effect()
                {
                    effectType = EffectType.POPULATION,
                    modifier = 0.7
                }
            }
        });
        cards.Push(new Card()
        {
            title = "Carta 4",
            effects = new List<Effect>() {
                new Effect()
                {
                    effectType = EffectType.POPULATION,
                    modifier = 1.3
                },
                new Effect()
                {
                    effectType = EffectType.NATURE,
                    modifier = 0.8
                }
            }
        });
        
        cards.Push(new Card()
        {
            title = "Carta 4",
            effects = new List<Effect>() {
                new Effect()
                {
                    effectType = EffectType.POPULATION,
                    modifier = 1.3
                },
                new Effect()
                {
                    effectType = EffectType.WATER,
                    modifier = 0.8
                },
                new Effect()
                {
                    effectType = EffectType.NATURE,
                    modifier = 0.8
                }
            }
        });
        cards.Push(new Card()
        {
            title = "Carta 5",
            effects = new List<Effect>() {
                new Effect()
                {
                    effectType = EffectType.TEMPERATURE,
                    modifier = 1.3
                }
            }
        });

        return cards;

    }
}
