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
    
    public void SetTemperatura(double value)
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

    private static double normalizeValue(double value)
    {
        if (value < 0)
            value = 0;
        else if (value > 100)
            value = 100;
        return value;
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCanvas()
    {
        canvas.UpdateResourceManagerText(water, population, temperature, nature);
    }
}
