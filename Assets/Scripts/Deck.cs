using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SimpleJSON;
using System.Globalization;

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
        Stack<Card> result = null;

        TextAsset cardsAsset = null;
        Deck cardList = null;

        
        try {
            
            Debug.Log("Cards loading from json init");

            result = new Stack<Card>();

            cardsAsset = Resources.Load<TextAsset>("Config/cards");
            Debug.Log("json: " + cardsAsset.ToString());

            var jsonData = JSON.Parse(cardsAsset.ToString());

            foreach(var cardData in jsonData["cards"].AsArray)
            {
                var efffects = new List<Effect>();
                foreach (var effectData in cardData.Value["effects"])
                {
                    var effect = new Effect();
                    effect.effectType = (EffectType) effectData.Value["effectType"].AsInt;
                    effect.modifier = effectData.Value["modifier"].AsDouble;
                    efffects.Add(effect);
                }
                var card = new Card();
                card.title = cardData.Value["title"];
                card.effects = efffects;
                for(var i = 0; i < cardData.Value["quantity"].AsInt;i++)
                {
                    result.Push(card);
                }
                
            }

            Debug.Log(string.Format($"Finished: {result.Count} cards loaded"));
            Debug.Log("Cards loading from json ended");

        } 
        catch (Exception ex) {
            Debug.LogError($"Error loading cards: {ex.Message}");
        }
        finally {
            cardsAsset = null;
            cardList = null;
        }

        return result;
    }
}
