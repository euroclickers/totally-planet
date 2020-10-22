using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverDirector : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        canvas.transform.Find("gameOverText").GetComponent<Text>().text = InfoBetweenScenes.isWin ? "YOU WON!" : "GAME OVER";
        canvas.transform.Find("gameOverText").GetComponent<Text>().color = InfoBetweenScenes.isWin ? new Color(171, 99, 9) : new Color(171, 9, 9);
    }

    public void LoadScene(string name)
    {
        InfoBetweenScenes.seedToUse = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void LoadSceneSameSeed(string name)
    {
        InfoBetweenScenes.seedToUse =  InfoBetweenScenes.seed;
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}