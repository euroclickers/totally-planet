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

    public void UpdateResourceManager(
        double water,
        double population,
        double temperature,
        double nature
    )
    {
        transform.Find("resources").Find("water").Find("fill").GetComponent<Image>().fillAmount = (float) water / 100;
        transform.Find("resources").Find("nature").Find("fill").GetComponent<Image>().fillAmount = (float) nature / 100;
        transform.Find("resources").Find("temperature").Find("fill").GetComponent<Image>().fillAmount = (float) temperature / 100;
        transform.Find("resources").Find("population").Find("fill").GetComponent<Image>().fillAmount = (float) population / 100;
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
