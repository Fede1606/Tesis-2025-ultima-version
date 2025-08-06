using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float amplitude = 0.1f; // Qué tanto sube y baja
    public float frequency = 1.5f;   // Qué tan rápido lo hace

    private Vector3 startPos;

    void Start()
    {
        // Guardamos la posición inicial
        startPos = transform.position;
    }

    void Update()
    {
        // Movimiento senoidal vertical
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }
}


