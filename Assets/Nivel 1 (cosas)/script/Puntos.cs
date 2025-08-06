using UnityEngine;
using TMPro; // ¡Esto es necesario para usar TextMeshProUGUI!

public class Puntos : MonoBehaviour
{
    public static int ValPunTos = 0;
    public TextMeshProUGUI puntosText;

    void Update()
    {
        puntosText.text = "Puntos : " + ValPunTos;
    }

    // Método para reiniciar los puntos
    public void ReiniciarPuntos()
    {
        ValPunTos = 0;
    }
}
