using UnityEngine;

public class ComidaMala : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            GameManager.Instance.PerderVida();
            Destroy(this.gameObject);
        } 
        
        
    }
}
