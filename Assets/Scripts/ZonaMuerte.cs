using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerController jugador = other.GetComponent<PlayerController>();

        if (jugador != null)
        {
            // Restaurar la vida
            jugador.vida = jugador.vidaMaxima;

            // Actualizar la barra
            if (jugador.barraVida != null)
            {
                jugador.barraVida.EstablecerVida(jugador.vida);
            }

            // Respawn
            GameManager.instancia.Respawn(other.gameObject);
        }
    }
}