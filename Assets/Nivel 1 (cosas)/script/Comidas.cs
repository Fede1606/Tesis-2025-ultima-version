using UnityEngine;
using TMPro;

public class Comidas : MonoBehaviour
{
    public int Valor = 1; // puntos que da esta comida
    public TextMeshProUGUI puntosText; // referencia al texto que muestra los puntos

    private static int puntosTotales = 0; // acumulador estático para que se mantenga entre objetos

    void Start()
    {
        puntosTotales = 0; // reinicia los puntos
        ActualizarTextoPuntos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            SumarPuntos(Valor); // sumamos los puntos al tocar la comida
            Destroy(this.gameObject); // destruimos la comida
        }
    }

    public void SumarPuntos(int valor)
    {
        puntosTotales += valor;
        Debug.Log("Puntos: " + puntosTotales);
        ActualizarTextoPuntos();
    }

    private void ActualizarTextoPuntos()
    {
        if (puntosText != null)
        {
            puntosText.text = puntosTotales.ToString();
        }
    }
}
