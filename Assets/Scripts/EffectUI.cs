﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectUI : MonoBehaviour
{
    public Effect effect;
    public Sprite populationSprite;
    public Sprite waterSprite;
    public Sprite natureSprite;
    public Sprite temperatureSprite;

    public Sprite modfierUp;
    public Sprite modifierDown;

    private float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("effectIcon").GetComponent<SpriteRenderer>().sprite = GetSpriteOfEffect();
        transform.Find("modifierIcon").GetComponent<SpriteRenderer>().sprite = GetSpriteOfModifier();
    }


    private Sprite GetSpriteOfEffect()
    {
        Sprite spriteToLoad = null;

        switch (effect.effectType)
        {
            case EffectType.POPULATION:
                spriteToLoad = populationSprite;
                break;
            case EffectType.NATURE:
                spriteToLoad = natureSprite;
                break;
            case EffectType.TEMPERATURE:
                spriteToLoad = temperatureSprite;
                break;
            case EffectType.WATER:
                spriteToLoad = waterSprite;
                break;

        }

        return spriteToLoad;
    }

    private Sprite GetSpriteOfModifier()
    {
        return effect.modifier > 1 ? modfierUp : modifierDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(effect.applying == true)
        {
            var resource = GameObject.Find("Canvas").transform.Find("resources").Find(effect.effectType.ToString().ToLower()).Find("fill");

            var destination = new Vector2(resource.transform.position.x, resource.transform.position.y + 1.5f);
           
            if ((transform.position.x <= destination.x + 0.1f && transform.position.x >= destination.x - 0.1f) &&
                (transform.position.y <= destination.y + 0.1f && transform.position.y >= destination.y - 0.1f))
            {
                Debug.Log("Finish effect");
                Destroy(this.gameObject);
                effect.finishApplying();
                
                
            }else
            {
                var currentSpeed = speed;
                transform.position = Vector3.MoveTowards(transform.position, destination, currentSpeed * Time.deltaTime);
            }

        }
    }
}
