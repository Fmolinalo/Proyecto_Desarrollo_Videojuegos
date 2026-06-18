using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vida = 3;

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;

        Debug.Log("Vida restante: " + vida);

        if (vida <= 0)
        {
            Debug.Log("Game Over");

            // Destruye al jugador o reinicia el nivel
            Destroy(gameObject);
        }
    }
}