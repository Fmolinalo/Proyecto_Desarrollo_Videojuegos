using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform jugador;

    public float velocidad = 2f;
    public float distanciaDeteccion = 5f;

    public int dano = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (jugador == null)
            return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia <= distanciaDeteccion)
        {
            Vector2 direccion = (jugador.position - transform.position).normalized;

            rb.linearVelocity = new Vector2(
                direccion.x * velocidad,
                rb.linearVelocity.y
            );

            // Girar el sprite
            if (direccion.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController jugador = collision.gameObject.GetComponent<PlayerController>();

            if (jugador != null)
            {
                jugador.RecibirDanio(dano);
            }
        }
    }
}