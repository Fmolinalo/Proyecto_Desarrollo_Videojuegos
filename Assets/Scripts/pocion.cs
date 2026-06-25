using UnityEngine;

public class pocion : MonoBehaviour
{
    [Header("Cantidad de vida que recupera")]
    public int curacion = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerController jugador = other.GetComponent<PlayerController>();

        if (jugador != null)
        {
            // Curar al jugador
            jugador.vida += curacion;

            // No superar la vida máxima
            if (jugador.vida > jugador.vidaMaxima)
            {
                jugador.vida = jugador.vidaMaxima;
            }

            // Actualizar la barra de vida
            if (jugador.barraVida != null)
            {
                jugador.barraVida.EstablecerVida(jugador.vida);
            }

            Debug.Log("Poción recogida. Vida: " + jugador.vida);

            Destroy(gameObject);
        }
    }
}