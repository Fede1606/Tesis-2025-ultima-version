using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public HUD hud;

	private MenuTerminoElJuego menuGameOver;


public int puntosObjetivo = 10; // Puedes ajustarlo desde el Inspector

private bool juegoTerminado = false;

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
    // Evitar que el jugador se mueva
    PlayerMovement jugador = FindObjectOfType<PlayerMovement>();
    if (jugador != null)
    {
        jugador.BloquearMovimiento();
    }

    // Esperar y reproducir la animación de salto 3 veces
    for (int i = 0; i < 3; i++)
    {
        if (jugador != null)
        {
            jugador.SaltarAnimacion(); // Asegúrate que este método reproduzca la animación
        }
        yield return new WaitForSeconds(1f); // Tiempo entre saltos
    }

    // Cargar el menú principal
    SceneManager.LoadScene("MainMenu"); // Cambia esto al nombre correcto de tu escena
}


	private int vidas = 3;

	private void Awake()
{
	if (Instance == null)
	{
		Instance = this;
	}
	else
	{
		Debug.Log("Cuidado! Mas de un GameManager en escena.");
	}

	menuGameOver = FindFirstObjectByType<MenuTerminoElJuego>();
	if (menuGameOver == null)
	{
		Debug.LogError("No se encontró el objeto con el script MenuTerminoElJuego en la escena.");
	}
}


	public void Perdiste()
	{
		Puntos.ValPunTos = 0; // Reiniciar puntos u otras variables si hace falta
		menuGameOver.ActivarGameOver(); // Mostrar el panel de Game Over
	}


	public void PerderVida()
	{
		vidas -= 1;

		hud.DesactivarVida(vidas); // Lo movemos arriba del if

		if (vidas == 0)
		{
			Perdiste(); // Mostrar el menú de Game Over
		}
	}


	public bool RecuperarVida()
	{
		if (vidas == 3)
		{
			return false;
		}

		hud.ActivarVida(vidas);
		vidas += 1;
		return true;
	}
}
