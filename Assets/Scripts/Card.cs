﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public string title;
    public List<Effect> effects;
    public EffectUI effectUI;
    private bool selected = false;

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
            effectUI = Instantiate(effectUI, new Vector3(0, 0, -5f), Quaternion.identity);
            effectUI.effect = effect;
            effectUI.transform.parent = transform;
            effectUI.transform.localScale = new Vector3(2.5f, 2.5f, 1);
            effectUI.transform.position = new Vector3(transform.position.x + positionModification, transform.position.y + 1.2f, -5f);
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
        if (!selected)
        {
            selected = true;
            transform.localScale = new Vector3(0.55f, 0.55f, 1);
            foreach (var effect in effects)
            {
                effect.apply();
            }
            GameObject.Find("Parent").BroadcastMessage("OnCardSelected", this, SendMessageOptions.DontRequireReceiver);
        }
    }
 
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(0.55f, 0.55f, 1);
    }

    private void OnMouseExit()
    {
        if (!selected)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }

    public Card cloneProperties(Card card)
    {
        effects = card.effects;
        title = card.title;

        return this;
    }

    public void OnEffectFinishedApplying()
    {
        bool allAreApplied = true;
        foreach(var effect in effects)
        {
            if(effect.applying)
            {
                allAreApplied = false;
            }
        }

        if(allAreApplied)
        {
            GameObject.Find("Parent").BroadcastMessage("OnCardSelectedFinished", SendMessageOptions.DontRequireReceiver);
        }
    }
}
