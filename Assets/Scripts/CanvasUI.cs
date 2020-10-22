using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    public ResourceUpdateUI resourceUpdateUI;

    private List<ResourceUpdateUI> resourceUpdateUIsCreated;
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
        transform.Find("resources").Find("water").Find("fill").GetComponent<Image>().fillAmount = (float)water / 100;
        transform.Find("resources").Find("nature").Find("fill").GetComponent<Image>().fillAmount = (float)nature / 100;
        transform.Find("resources").Find("temperature").Find("fill").GetComponent<Image>().fillAmount = (float)temperature / 100;
        transform.Find("resources").Find("population").Find("fill").GetComponent<Image>().fillAmount = (float)population / 100;
    }

    public void UpdateRemainingCardsLabel(int remainingCards)
    {
        transform.Find("DeckRemainingCardsLabel").GetComponent<Text>().text = remainingCards.ToString();
    }

    public void UpdateSeedLabel(int seed)
    {
        transform.Find("seedLabel").GetComponent<Text>().text = "Seed: " + seed;
    }

    public void CreateUpdateResourceAnimation(
        bool? waterIsIncreasing,
        bool? populationIsIncreasing,
        bool? temperatureIsIncreasing,
        bool? natureIsIncreasing
    )
    {
        resourceUpdateUIsCreated = new List<ResourceUpdateUI>();
        CreateOneResourceAnimation("water", waterIsIncreasing);
        CreateOneResourceAnimation("population", populationIsIncreasing);
        CreateOneResourceAnimation("temperature", temperatureIsIncreasing);
        CreateOneResourceAnimation("nature", natureIsIncreasing);
    }

    private void CreateOneResourceAnimation(string type, bool? isIncreasing)
    {
        if(isIncreasing != null)
        {
            var parentToAttach = transform.Find("resources").Find(type).transform;
            var resourceUpdate = Instantiate(resourceUpdateUI, parentToAttach.position, Quaternion.identity);
            resourceUpdate.setIncreasing(isIncreasing.Value);
            resourceUpdate.transform.name = "ResourceUpdate";
            resourceUpdate.transform.parent = parentToAttach.transform;
            resourceUpdate.transform.localScale = new Vector3(100, 100, 1);
            resourceUpdate.transform.localPosition = new Vector3(20, 30, -500);
            resourceUpdateUIsCreated.Add(resourceUpdate);

        }
        
    }

    public void OnResourceUpdateUIDestroyed(ResourceUpdateUI resourceUpdateUI)
    {
        resourceUpdateUIsCreated.Remove(resourceUpdateUI);
        if(resourceUpdateUIsCreated.Count == 0)
        {
            GameObject.Find("Parent").BroadcastMessage("OnCanvasUIAllResourcesUIDestroyed", SendMessageOptions.DontRequireReceiver);

        }
    }
}
