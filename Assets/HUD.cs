using UnityEngine;
using TMPro;


public class HUD : MonoBehaviour
{
    public GameManagerNivel1 gameManagerNivel1;
	public GameManagerNivel2 gameManagerNivel2;	
	
	void Update() {

		
	}

	public GameObject[] vidas;
    
	

	public void DesactivarVida(int indice) {
		vidas[indice].SetActive(false);
	}

	public void ActivarVida(int indice) {
		vidas[indice].SetActive(true);
	}
    
}
