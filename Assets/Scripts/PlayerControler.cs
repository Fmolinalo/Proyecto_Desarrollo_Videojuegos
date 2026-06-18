using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;

    // Vida del jugador
    public int vida = 3;

    private Rigidbody2D rb;

    // Número máximo de saltos
    public int maxSaltos = 2;
    private int saltosRestantes;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        saltosRestantes = maxSaltos;
    }

    void Update()
    {
        // Movimiento horizontal
        float movimiento = 0;

        if (Input.GetKey(KeyCode.A))
            movimiento = -1;

        if (Input.GetKey(KeyCode.D))
            movimiento = 1;

        rb.linearVelocity = new Vector2(
            movimiento * velocidad,
            rb.linearVelocity.y
        );

        // Salto y doble salto
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );

            saltosRestantes--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Recupera los saltos al tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            saltosRestantes = maxSaltos;
        }
    }

    // Método para recibir daño
    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;

        Debug.Log("Vida restante: " + vida);

        if (vida <= 0)
        {
            Debug.Log("¡Has perdido!");

            // Destruir al jugador
            Destroy(gameObject);

            // Si prefieres reiniciar el nivel, reemplaza la línea anterior por:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}