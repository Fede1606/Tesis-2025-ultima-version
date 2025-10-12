using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerNivel2 : MonoBehaviour
{
    public static GameManagerNivel2 Instance { get; private set; }

    public HUD hud;
    private MenuTerminoElJuego menuGameOver;

    private int vidas = 1; // 👈 Solo una vida en este nivel

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Cuidado! Más de un GameManagerNivel2 en escena.");
        }

        menuGameOver = FindFirstObjectByType<MenuTerminoElJuego>();
        if (menuGameOver == null)
        {
            Debug.LogError("No se encontró el objeto con el script MenuTerminoElJuego en la escena.");
        }
    }

    public void Perdiste()
    {
        Puntos.ValPunTos = 0; // Reinicia puntos u otras variables si hace falta
        menuGameOver.ActivarGameOver(); // Muestra el menú de Game Over
    }

    public void PerderVida()
    {
        vidas -= 1;
        hud.DesactivarVida(vidas);

        if (vidas == 0)
        {
            Perdiste();
        }
    }

    public bool RecuperarVida()
    {
        // Por si en algún momento querés que pueda ganar una vida extra
        if (vidas >= 3)
            return false;

        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}

