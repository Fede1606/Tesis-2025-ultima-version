using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            // Si existe el GameManager del nivel 1, usalo
            if (GameManagerNivel1.Instance != null)
            {
                GameManagerNivel1.Instance.PerderVida();
            }
            // Si no, probá con el del nivel 2
            else if (GameManagerNivel2.Instance != null)
            {
                GameManagerNivel2.Instance.PerderVida();
            }
            else
            {
                Debug.LogWarning("⚠ No se encontró ningún GameManager activo en la escena.");
            }
        }
    }
}
