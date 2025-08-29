using UnityEngine;
using UnityEngine.UI;

public class controladorjuego : MonoBehaviour
{
    [SerializeField] private float tiempomaximo;
    [SerializeField] private Slider slider;
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
        if(tiempoActual >= 0){
            slider.value=tiempoActual;
            slider.maxValue=tiempomaximo;

        }
        if (tiempoActual <= 0)
        {
            

            Debug.Log("¡Tiempo terminado!");
            CambiarTemporizador(false);
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
