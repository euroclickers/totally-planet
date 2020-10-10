using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    public Card card;
    public ResourceManager resourceManager;
    public int seed = 0;
    public CanvasUI canvas;
    // Start is called before the first frame update
    void Start()
    {
        seed = (seed == 0) ? new System.Random().Next() : seed;
        canvas.UpdateSeedLabel(seed);

        var deck = new Deck(seed);

        Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity).cloneProperties(deck.GetNextCard());
        Instantiate(card, new Vector3(4, 0, 0), Quaternion.identity).cloneProperties(deck.GetNextCard());
        Instantiate(card, new Vector3(-4, 0, 0), Quaternion.identity).cloneProperties(deck.GetNextCard());
    }

    // Update is called once per frame
    void Update()
    {


    }
}
