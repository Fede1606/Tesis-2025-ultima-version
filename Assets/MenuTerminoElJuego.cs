using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTerminoElJuego : MonoBehaviour
{
    public GameObject gameOverPanel; // Asignalo desde el Inspector
    public string nombreEscenaMenu;  // Nombre de la escena principal (ej: "Menu")

    private bool juegoTerminado = false;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Ocultarlo al inicio
    }


    public void ActivarGameOver()
    {
        if (!juegoTerminado)
        {
            juegoTerminado = true;
            Time.timeScale = 0f; // Pausa el juego
            gameOverPanel.SetActive(true); // Mostrar panel
        }
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void GoMainMenu()
    {
		Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}


