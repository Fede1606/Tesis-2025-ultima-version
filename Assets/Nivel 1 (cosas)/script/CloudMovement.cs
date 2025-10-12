using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float resetDistance = 20.0f; // cuando el jugador se aleja demasiado
    public Transform player; // arrastrá al jugador acá en el Inspector

    private float startOffsetX;

    void Start()
    {
        if (player != null)
            startOffsetX = transform.position.x - player.position.x;
    }

    void Update()
    {
        if (player == null) return;

        // Movimiento continuo de las nubes
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        // Si el jugador se aleja demasiado, reposicionarlas cerca
        float distance = Mathf.Abs(transform.position.x - player.position.x - startOffsetX);
        if (distance > resetDistance)
        {
            Vector3 newPos = transform.position;
            newPos.x = player.position.x + startOffsetX + resetDistance * Mathf.Sign(startOffsetX);
            transform.position = newPos;
        }
    }
}
