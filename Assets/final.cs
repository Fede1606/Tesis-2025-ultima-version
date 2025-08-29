using UnityEngine;

public class final : MonoBehaviour
{
   [SerializeField] private controladorjuego controladorjuego;


   private void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("player")){
        controladorjuego.ActivarTemporizador();
    }
   }
}
