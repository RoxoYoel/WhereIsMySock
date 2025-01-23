using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject SettingsUI; 


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettings()
    {
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("La aplicación se ha cerrao.");

    }
    public void SettingsBack()
    {
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);
    }
}
