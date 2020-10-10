using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public EffectType effectType;
    public double modifier;



    public void apply()
    {

        var resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();

        switch (effectType)
        {
            case EffectType.POPULATION:
                resourceManager.SetPopulation(resourceManager.population * modifier);
                break;
            case EffectType.NATURE:
                resourceManager.SetNature(resourceManager.nature * modifier);
                break;
            case EffectType.TEMPERATURE:
                resourceManager.SetTemperatura(resourceManager.temperature * modifier);
                break;
            case EffectType.WATER:
                resourceManager.SetWater(resourceManager.water * modifier);
                break;

        }
    }
}
