
using UnityEngine;
using UnityEngine.UI;

public class MenuDirector : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        InfoBetweenScenes.seedToUse = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void LoadSceneWithSeed(string name)
    {
        if(
            canvas.transform.Find("seed").Find("seedToggle").GetComponent<Toggle>().isOn
            ) {
            var result = 0;
            int.TryParse(canvas.transform.Find("seed").Find("seedInput").GetComponent<InputField>().textComponent.text, out result);
            InfoBetweenScenes.seedToUse = result;
        }
        else
        {
            InfoBetweenScenes.seedToUse = 0;
        }
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void ToggleSeedInput(bool enabled)
    {
        enabled = canvas.transform.Find("seed").Find("seedToggle").GetComponent<Toggle>().isOn;
        canvas.transform.Find("seed").Find("seedInput").GetComponent<InputField>().interactable = enabled;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
