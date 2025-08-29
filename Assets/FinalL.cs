using UnityEngine;

public class FinalL : MonoBehaviour
{
    [SerializeField] private controladorjuego controladorjuego;


   private void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("player")){
        controladorjuego.DesactivarTemporizador();
    }
   }
}
