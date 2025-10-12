using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    [TextArea(3, 10)] public string[] lineasDialogo; // varias líneas de texto
    public float velocidadEscritura = 0.05f;
    public string siguienteEscena;

    private int indice = 0;
    private bool escribiendo = false;

    void Start()
    {
        textoUI.text = "";
        StartCoroutine(EscribirLinea());
    }

    void Update()
    {
        // Si se presiona espacio y ya terminó de escribir la línea
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!escribiendo)
            {
                indice++;
                if (indice < lineasDialogo.Length)
                {
                    StartCoroutine(EscribirLinea());
                }
                else
                {
                    SceneManager.LoadScene(siguienteEscena); // cambiar de escena al final
                }
            }
        }
    }

    IEnumerator EscribirLinea()
    {
        escribiendo = true;
        textoUI.text = "";

        foreach (char letra in lineasDialogo[indice])
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        escribiendo = false;
    }
}
