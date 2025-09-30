using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1f;

    private Rigidbody2D ballRb;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;

        ballRb.linearVelocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.linearVelocity *= velocityMultiplier;
        }
    }

    void Update()
    {
        // Aquí podrías reiniciar la bola si se sale de los límites, por ejemplo
    }
}

