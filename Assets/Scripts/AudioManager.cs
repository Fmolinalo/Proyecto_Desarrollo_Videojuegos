using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;

    private AudioSource audioSource;

    [Header("Sonidos")]
    public AudioClip moneda;
    public AudioClip salto;
    public AudioClip enemigo;
    public AudioClip checkpoint;
    public AudioClip pocion;
    public AudioClip gameOver;
    public AudioClip boton;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void Reproducir(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
