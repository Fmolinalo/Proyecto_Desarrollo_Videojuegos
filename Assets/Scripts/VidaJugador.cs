using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 3;
    public int vidaActual;

    public BarraVida barraVida;

    void Start()
    {
        vidaActual = vidaMaxima;

        if (barraVida != null)
        {
            barraVida.vidaMaxima = vidaMaxima;
            barraVida.EstablecerVida(vidaActual);
        }
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual < 0)
            vidaActual = 0;

        Debug.Log("Vida restante: " + vidaActual);

        if (barraVida != null)
        {
            barraVida.EstablecerVida(vidaActual);
        }

        if (vidaActual <= 0)
        {
            Debug.Log("Game Over");

            Destroy(gameObject);
        }
    }
}