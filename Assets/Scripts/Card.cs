using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card : MonoBehaviour
{
    
    public string title;
    public List<Effect> effects;


    public EffectUI effectUI;

    // Start is called before the first frame update
    void Start()
    {
        var cardTitle = transform.Find("cardTitle");
        cardTitle.GetComponent<TextMesh>().text = title;

        renderEffectsUI();
    }

    private void renderEffectsUI()
    {
        var count = effects.Count;
        int i = 0;
        foreach(var effect in effects)
        {
            var positionModification = getPositionMoficiation(count, i);
            effectUI = Instantiate(effectUI, new Vector3(0, 0, -2.5f), Quaternion.identity);
            effectUI.effect = effect;
            effectUI.transform.parent = transform;
            effectUI.transform.localScale = new Vector3(2.5f, 2.5f, 1);
            effectUI.transform.position = new Vector3(transform.position.x + positionModification, transform.position.y + 1.2f, -2.5f);
            i++;
        }
       
    }

    private float getPositionMoficiation(int count, int index)
    {
        if(count == 1)
        {
            return 0.5f;
        }else if(count == 2)
        {
            return (index == 0) ? -0.5f : 1.5f;
        }else if(count == 3)
        {
            if(index == 0)
            {
                return 0.5f;
            }
            return (index == 1) ? -0.5f : 1.5f;
        }

        return 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        foreach(var effect in effects)
        {
            effect.apply();
        }
        var gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        gameDirector.NextTurn();
    }

    public Card cloneProperties(Card card)
    {
        effects = card.effects;
        title = card.title;

        return this;
    }
}
