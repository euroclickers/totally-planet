using System;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    
    public ResourceManager resourceManager;
    public int seed = 0;
    public CanvasUI canvas;
    public CardSelection cardSelection;
    // Start is called before the first frame update
    void Start()
    {
        seed = InfoBetweenScenes.seedToUse;
        seed = (seed == 0) ? new System.Random().Next() : seed;
        InfoBetweenScenes.seed = seed;
        cardSelection.seed = seed;
        canvas.UpdateSeedLabel(seed);
        resourceManager.initResources(seed);
        canvas.transform.Find("DeckRemainingCardsLabel").GetComponent<Text>().text = cardSelection.getRemainingTurns().ToString();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void NextTurn()
    {
        if (!checkEndGame())
        {
            GameObject.Find("Parent").BroadcastMessage("OnGameDirectorNewTurnStarted", SendMessageOptions.DontRequireReceiver);
            canvas.transform.Find("DeckRemainingCardsLabel").GetComponent<Text>().text = cardSelection.getRemainingTurns().ToString();
        }
        
    }

    private bool checkEndGame()
    {
        if(resourceManager.population <= 0)
        {
            InfoBetweenScenes.isWin = false;
            Debug.Log("LOSEEER");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");

            return true;
        }
        return false;
    }

    public void OnCardSelectionCardSelectedFinished()
    {
        resourceManager.ResourceUpdate();
    }

    public void OnResourceManagerResourceUpdateFinished()
    {
        NextTurn();
    }

    public void OnCardSelectionOutOfCards()
    {
        InfoBetweenScenes.isWin = true;
        Debug.Log("WINNER");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
