using UnityEngine;

public class Padel : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPadel1;
    private float yBound = 3.75f;

    void Update()
    {
        float movement;

        if (isPadel1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

     
        Vector2 paddelPosition = transform.position;
        paddelPosition.y = Mathf.Clamp(paddelPosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddelPosition;
    }
}
