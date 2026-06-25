using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [Header("Imagen de la barra (Full)")]
    public Image barraVida;

    [Header("Configuración")]
    public float vidaMaxima = 3f;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarBarra();
    }

    public void RecibirDanio(float dano)
    {
        vidaActual -= dano;

        if (vidaActual < 0)
            vidaActual = 0;

        ActualizarBarra();

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void Curar(float cantidad)
    {
        vidaActual += cantidad;

        if (vidaActual > vidaMaxima)
            vidaActual = vidaMaxima;

        ActualizarBarra();
    }

    public void ActualizarBarra()
    {
        if (barraVida != null)
        {
            barraVida.fillAmount = vidaActual / vidaMaxima;
        }
    }

    public void EstablecerVida(float vida)
    {
        vidaActual = Mathf.Clamp(vida, 0, vidaMaxima);
        ActualizarBarra();
    }

    void Morir()
    {
        Debug.Log("Game Over");

        // Si tienes GameManager, descomenta esta línea:
        // FindFirstObjectByType<GameManager>().GameOver();
    }
}