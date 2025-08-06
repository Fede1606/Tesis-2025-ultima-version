using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuinicial : MonoBehaviour
{
   public void jugar()
   {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
   {
      Debug.Log ("Salir...");
      Application.Quit();
    }
   
}
