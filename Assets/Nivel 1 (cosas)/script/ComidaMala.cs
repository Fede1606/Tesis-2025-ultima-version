using UnityEngine;

public class ComidaMala : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            GameManagerNivel1.Instance.PerderVida();
            Destroy(this.gameObject);
        } 
        
        
    }
}
