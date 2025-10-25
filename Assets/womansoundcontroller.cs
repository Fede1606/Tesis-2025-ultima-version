using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoSaltar;
    public AudioClip sonidoMovimiento;
    public AudioClip stepClip;
    public AudioSource jumpSource;
    public AudioClip jumpClip;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(sonidoSaltar);

    }

    public void PlayStepSound()
    {
        if (stepSource != null && !stepSource.isPlaying)
        {
            stepSource.clip = stepClip;
            stepSource.loop = true; // 🔁 se repite mientras camina
            stepSource.Play();
        }
    }

    public void StopStepSound()
    {
        if (stepSource != null && stepSource.isPlaying)
        {
            stepSource.Stop();
        }
    }

    public bool IsStepSoundPlaying()
    {
        return stepSource != null && stepSource.isPlaying;
    }

    public void PlayJumpSound()
    {
        if (jumpSource != null && jumpClip != null)
        {
            jumpSource.PlayOneShot(jumpClip);
        }
    }
}
