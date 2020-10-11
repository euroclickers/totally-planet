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
                Debug.Log($"Effect New Population: {resourceManager.population * modifier}, (Previous: {resourceManager.population})");
                resourceManager.SetPopulation(resourceManager.population * modifier);
                break;
            case EffectType.NATURE:
                Debug.Log($"Effect New Nature: {resourceManager.nature * modifier}, (Previous: {resourceManager.nature})");
                resourceManager.SetNature(resourceManager.nature * modifier);
                break;
            case EffectType.TEMPERATURE:
                Debug.Log($"Effect New Temperature: {resourceManager.temperature * modifier}, (Previous: {resourceManager.temperature})");
                resourceManager.SetTemperature(resourceManager.temperature * modifier);
                break;
            case EffectType.WATER:
                Debug.Log($"Effect New Water: {resourceManager.water * modifier}, (Previous: {resourceManager.water})");
                resourceManager.SetWater(resourceManager.water * modifier);
                break;

        }
    }
}
