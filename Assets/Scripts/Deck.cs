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

    private Stack<Card> loadCards()
    {
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
