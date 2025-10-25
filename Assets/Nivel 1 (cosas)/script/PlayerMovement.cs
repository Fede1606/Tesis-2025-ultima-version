using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerSoundController PlayerSoundController;
    public float velocidad = 5f;
    public float fuerzasalto = 10f;
    public float longitudRaycast = 0.2f;
    public LayerMask capaSuelo;

    private Animator animator;
    private bool enSuelo;
    private Rigidbody2D rd;
    private Vector3 escalaInicial;
    private bool puedeMoverse = true;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        escalaInicial = transform.localScale;
    }

    void Update()
    {
        if (!puedeMoverse)
            return;

        // Movimiento horizontal con física
        float horizontal = Input.GetAxis("Horizontal");
        rd.linearVelocity = new Vector2(horizontal * velocidad, rd.linearVelocity.y);

        // Animación de movimiento
        animator.SetFloat("movement", Mathf.Abs(horizontal));

        // Voltear sprite
        if (horizontal < 0)
            transform.localScale = new Vector3(-escalaInicial.x, escalaInicial.y, escalaInicial.z);
        else if (horizontal > 0)
            transform.localScale = new Vector3(escalaInicial.x, escalaInicial.y, escalaInicial.z);

        // Raycast para detectar el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;
        animator.SetBool("ensuelo", enSuelo);

        // 🔊 Control de sonido de pasos
        if (enSuelo && Mathf.Abs(horizontal) > 0.1f)
        {
            // Si se mueve y no está sonando, lo inicia
            if (!PlayerSoundController.IsStepSoundPlaying())
            {
                PlayerSoundController.PlayStepSound();
            }
        }
        else
        {
            // Si no se mueve o está en el aire, lo detiene
            if (PlayerSoundController.IsStepSoundPlaying())
            {
                PlayerSoundController.StopStepSound();
            }
        }

        // Salto
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rd.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);
            PlayerSoundController.PlayJumpSound();
        }
    }

    // Dibuja el raycast en la escena
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }

    // Bloquea el movimiento desde GameManager
    public void BloquearMovimiento()
    {
        puedeMoverse = false;
        PlayerSoundController.StopStepSound(); // detiene sonido si se bloquea
    }

    public void SaltarAnimacion()
    {
        if (animator != null)
        {
            animator.SetTrigger("jump");
        }
    }
}
