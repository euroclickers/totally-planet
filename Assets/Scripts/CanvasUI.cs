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
        transform.Find("resources").Find("waterLabel").GetComponent<Text>().text = "Water: " + (int) water;
        transform.Find("resources").Find("populationLabel").GetComponent<Text>().text = "Population: " + (int) population;
        transform.Find("resources").Find("temperatureLabel").GetComponent<Text>().text = "Temperature: " + (int) temperature;
        transform.Find("resources").Find("natureLabel").GetComponent<Text>().text = "Nature: " + (int) nature;

        transform.Find("resources").Find("water").Find("fill").GetComponent<Image>().fillAmount = (float) water / 100;
    }

    public void UpdateRemainingCardsLabel (int remainingCards)
    {
        transform.Find("DeckRemainingCardsLabel").GetComponent<Text>().text = remainingCards.ToString();
    }

    public void UpdateSeedLabel(int seed)
    {
        transform.Find("seedLabel").GetComponent<Text>().text = "Seed: " + seed;
    }
}
