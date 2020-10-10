using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string title;
    public List<Effect> effects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("hi");
        foreach(var effect in effects)
        {
            effect.apply();
        }
    }

    public void cloneProperties(Card card)
    {
        effects = card.effects;
        title = card.title;
    }
}
