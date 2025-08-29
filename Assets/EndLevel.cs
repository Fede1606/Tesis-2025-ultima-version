using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
     // Nombre de la escena del menú principal en tu proyecto
    public string MainMenu = "MainMenu";

    // Se llama cuando un objeto con un Collider2D entra en este trigger 2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que ha entrado en el trigger es el jugador.
        if (other.CompareTag("Player"))
        {
            // Carga la escena del menú principal
            SceneManager.LoadScene(MainMenu);
        }
    }

    // Se llama cuando ocurre una colisión física 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Alternativa: Si usas colisiones físicas en lugar de triggers
        if (collision.gameObject.CompareTag("Player"))
        {
            // Carga la escena del menú principal
            SceneManager.LoadScene(MainMenu);
        }
    }
}
