using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public double water = 0;
    public double temperature = 0;
    public double population = 0;
    public double nature = 0;

    private double newWater = 0;
    private double newTemperature = 0;
    private double newPopulation = 0;
    private double newNature = 0;

    private bool applyingUpdate = false;

    public CanvasUI canvas;

    public void initResources(int seed)
    {
        var rnd = new System.Random(seed);

        water = rnd.Next(40, 60);
        temperature = rnd.Next(40, 60);
        population = rnd.Next(40, 60);
        nature = rnd.Next(40, 60);
        UpdateDependentInfo();
    }

    public void SetWater(double water)
    {
        water = normalizeValue(water);

        this.water = water;
        UpdateDependentInfo();
    }

    public void SetTemperature(double value)
    {
        temperature = normalizeValue(value);

        UpdateDependentInfo();
    }

    public void SetPopulation(double value)
    {
        population = normalizeValue(value);

        UpdateDependentInfo();
    }

    public void SetNature(double value)
    {
        nature = normalizeValue(value);

        UpdateDependentInfo();
    }

    public void ResourceUpdate()
    {

        newTemperature = temperature + water * (-0.1) + population * 0.2;
        Debug.Log($"New temperature {newTemperature} (T:{temperature}, W:{water * (-0.1)}, P:{population * 0.2} )");

        newWater = (GaussDistribution(temperature, 25, 50, 15, -15)) + water + nature * (0.1) + population * (-0.2);
        Debug.Log($"New water {newWater} (T:{(GaussDistribution(temperature, 25, 50, 15, -15))}, W:{water}, N:{nature * (0.1)}, P:{population * (-0.2)}");

        newNature = (GaussDistribution(temperature, 25, 50, 15, -15)) + (GaussDistribution(water, 45, 100, 60, -30)) + nature + population * (-0.2);
        Debug.Log($"New nature {newNature} (T:{(GaussDistribution(temperature, 25, 50, 15, -15))}, W:{ (GaussDistribution(water, 45, 100, 60, -30))}, N:{nature}, P:{population * (-0.2)}");

        newPopulation = (GaussDistribution(temperature, 45, 50, 15, -25)) + (GaussDistribution(water, 25, 50, 20, -15)) + (GaussDistribution(nature, 60, 100, 80, -50)) + population;
        Debug.Log($"New population {newPopulation} (T:{(GaussDistribution(temperature, 45, 50, 15, -25))}, W:{ (GaussDistribution(water, 25, 50, 20, -15))}, N:{(GaussDistribution(nature, 60, 100, 80, -50))}, P:{population}");

        canvas.CreateUpdateResourceAnimation(
            water == newWater ? null : (bool?)(newWater > water),
            population == newPopulation ? null : (bool?)(newPopulation > population),
            temperature == newTemperature ? null : (bool?)(newTemperature > temperature),
            nature == newNature ? null : (bool?)(newNature > nature)
        );

    }

    // f(x) = a * e^(-(x-b)^2/(2 * c^2)) where "a" controls the height, "b" controls the center and "c" the width, baseLine controls the position across y axis
    private double GaussDistribution(double x, double a, double b, double c, double baseLine)
    {
        var v1 = (x - b);
        var v2 = (v1 * v1) / (2 * (c * c));
        var v3 = a * Mathf.Exp((float)-v2);
        var v4 = v3 + baseLine;
        return v4;
    }

    private static double normalizeValue(double value)
    {
        if (value < 0)
            value = 0;
        else if (value > 100)
            value = 100;
        return value;
    }


    // Start is called before the first frame update
    private void Start()
    {
        UpdateDependentInfo();
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    public void OnCanvasUIAllResourcesUIDestroyed()
    {
        SetTemperature(newTemperature);
        SetWater(newWater);
        SetNature(newNature);
        SetPopulation(newPopulation);
        UpdateDependentInfo();
        GameObject.Find("Parent").BroadcastMessage("OnResourceManagerResourceUpdateFinished", SendMessageOptions.DontRequireReceiver);
        
    }

    private void UpdateDependentInfo()
    {
        canvas.UpdateResourceManager(water, population, temperature, nature);
        InfoBetweenScenes.water = water;
        InfoBetweenScenes.temperature = temperature;
        InfoBetweenScenes.population = population;
        InfoBetweenScenes.nature = nature;
    }
}