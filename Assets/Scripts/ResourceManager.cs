using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public double water = 0;
    public double temperature = 0;
    public double population = 0;
    public double nature = 0;

    public CanvasUI canvas;

    public void SetWater(double water)
    {
        water = normalizeValue(water);

        this.water = water;
        UpdateCanvas();
    }

    public void SetTemperature(double value)
    {
        temperature = normalizeValue(value);

        UpdateCanvas();
    }

    public void SetPopulation(double value)
    {
        population = normalizeValue(value);

        UpdateCanvas();
    }

    public void SetNature(double value)
    {
        nature = normalizeValue(value);

        UpdateCanvas();
    }

    public void ResourceUpdate()
    {

        var newTemperature = temperature + water * (-0.1) + population * 0.1;

        var newWater = temperature * (-0.1) + water + nature * (0.1) + population * (-0.1);

        var newNature = (GaussDistribution(temperature, 25, 50, 15) - 15) + water * (0.1) + nature + population * (-0.1);

        var newPopulation = (GaussDistribution(temperature, 25, 50, 15) - 15) + (GaussDistribution(water, 25, 50, 20) - 15) + nature * (0.1) + population;
        Debug.Log("Gauss Distribution result for population modification by temperature" + (GaussDistribution(temperature, 25, 50, 15) - 15));
        Debug.Log("Gauss Distribution result for population modification by water" + (GaussDistribution(water, 25, 50, 20) - 15));

        Debug.Log("Temperature variation: " + (newTemperature - temperature));
        Debug.Log("Water variation: " + (newWater - water));
        Debug.Log("Nature variation: " + (newNature - nature));
        Debug.Log("Population variation: " + (newPopulation - population));

        temperature = newTemperature;
        water = newWater;
        nature = newNature;
        population = newPopulation;
        UpdateCanvas();
    }

    // f(x) = a * e^(-(x-b)^2/(2 * c^2)) where "a" controls the height, "b" controls the center and "c" the width 
    private double GaussDistribution(double x, double a, double b, double c)
    {
        var v1 = (x - b);
        var v2 = (v1 * v1) / (2 * (c * c));
        var v3 = a * Mathf.Exp((float)-v2);
        return v3;
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
        UpdateCanvas();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void UpdateCanvas()
    {
        canvas.UpdateResourceManagerText(water, population, temperature, nature);
    }
}