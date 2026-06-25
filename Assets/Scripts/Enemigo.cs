using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform jugador;

    public float velocidad = 2f;
    public float distanciaDeteccion = 5f;

    public int dano = 1;
    public int vida = 100;

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

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;

        Debug.Log(gameObject.name + " recibió " + cantidad + " de daño");
        Debug.Log("Vida restante: " + vida);

        if (vida <= 0)
        {
            Debug.Log("Enemigo eliminado");
            Destroy(gameObject);
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.RecibirDanio(dano);
        }
    }
}
        }
    
