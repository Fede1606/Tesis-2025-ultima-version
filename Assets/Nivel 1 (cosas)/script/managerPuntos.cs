using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerPuntos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "comidabuena")
        {
            Puntos.ValPunTos += 1;
            Destroy(col.gameObject);
        }
        
        GameManagerNivel1.Instance.RevisarPuntos(Puntos.ValPunTos);
    }

    
}
