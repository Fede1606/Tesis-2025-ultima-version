using UnityEngine;
using UnityEngine.UI;

public class controladorjuego : MonoBehaviour
{
    [SerializeField] private float tiempomaximo;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject MenuGameOver; // 👈 tu pantalla de game over

    private float tiempoActual;
    private bool tiempoActivado = false;
    

    private void Update()
    {
        if (tiempoActivado)
        {
            Cambiarcontador();
        }
    }

    private void Cambiarcontador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual > 0)
        {
            slider.value = tiempoActual;
            slider.maxValue = tiempomaximo;
        }
        else
        {
            Debug.Log("¡Tiempo terminado!");
            GameManager.Instance.PerderVida();
        }

    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempomaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
