using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateResourceManagerText(
        double water,
        double population,
        double temperature,
        double nature
    )
    {
        transform.Find("waterLabel").GetComponent<Text>().text = "Water: " + (int) water;
        transform.Find("populationLabel").GetComponent<Text>().text = "Population: " + (int) population;
        transform.Find("temperatureLabel").GetComponent<Text>().text = "Temperature: " + (int) temperature;
        transform.Find("natureLabel").GetComponent<Text>().text = "Nature: " + (int) nature;

    }

    public void UpdateSeedLabel(int seed)
    {
        transform.Find("seedLabel").GetComponent<Text>().text = "Seed: " + seed;
    }
}
