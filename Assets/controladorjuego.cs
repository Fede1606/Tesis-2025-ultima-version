using UnityEngine;

public class controladorjuego : MonoBehaviour
{
    [SerializeField] private float tiempomaximo;

    private float tiempoActual;
    private bool tiempoActivado = false;
    private void Start()
    {
        ActivarTemporizador();
    }

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
