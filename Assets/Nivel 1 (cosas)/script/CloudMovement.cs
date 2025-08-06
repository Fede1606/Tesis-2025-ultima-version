using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float resetPositionX = -10.0f;
    public float startPositionX = 10.0f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < resetPositionX)
        {
            Vector2 newPos = new Vector2(startPositionX, transform.position.y);
            transform.position = newPos;
        }
    }
}

