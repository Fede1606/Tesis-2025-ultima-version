using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject PanelOptions;
    public void optionsPanel()
    {
        Time.timeScale=0;
        PanelOptions.SetActive(true);

    }
    public void Return()
    {
        Time.timeScale=1;
        PanelOptions.SetActive(false);
    }
    public void AnotherOptions()
    {

    }



    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
