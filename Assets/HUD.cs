using UnityEngine;
using TMPro;


public class HUD : MonoBehaviour
{
    public GameManager gameManager ;
	
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
