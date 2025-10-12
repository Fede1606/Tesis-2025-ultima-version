using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagerNivel1 : MonoBehaviour
{
    public static GameManagerNivel1 Instance { get; private set; }

    public HUD hud;
    private MenuTerminoElJuego menuGameOver;

    public int puntosObjetivo = 10; // Ajustable desde el Inspector
    private bool juegoTerminado = false;

    private int vidas = 3; // 👈 Nivel 1 arranca con 3 vidas

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Más de un GameManagerNivel1 en escena.");
        }

        menuGameOver = FindFirstObjectByType<MenuTerminoElJuego>();
        if (menuGameOver == null)
        {
            Debug.LogError("No se encontró el objeto con el script MenuTerminoElJuego en la escena.");
        }
    }

    public void RevisarPuntos(int puntosActuales)
    {
        if (!juegoTerminado && puntosActuales >= puntosObjetivo)
        {
            juegoTerminado = true;
            StartCoroutine(FinalizarJuego());
        }
    }

    private IEnumerator FinalizarJuego()
    {
        PlayerMovement jugador = FindObjectOfType<PlayerMovement>();
        if (jugador != null) jugador.BloquearMovimiento();

        for (int i = 0; i < 3; i++)
        {
            if (jugador != null) jugador.SaltarAnimacion();
            yield return new WaitForSeconds(1f);
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void Perdiste()
    {
        Puntos.ValPunTos = 0;
        menuGameOver.ActivarGameOver();
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
        if (vidas == 3) return false;

        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}
