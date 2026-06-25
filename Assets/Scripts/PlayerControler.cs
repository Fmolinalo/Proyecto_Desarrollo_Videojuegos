using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;

    [Header("Vida")]
    public int vidaMaxima = 3;
    public int vida = 3;

    [Header("Barra de Vida")]
    public BarraVida barraVida;

    private Rigidbody2D rb;

    [Header("Saltos")]
    public int maxSaltos = 2;
    private int saltosRestantes;

    void Start()
{
    rb = GetComponent<Rigidbody2D>();

    saltosRestantes = maxSaltos;

    vida = vidaMaxima;

    GameManager.instancia.EstablecerInicio(transform.position);

    if (barraVida != null)
    {
        barraVida.vidaMaxima = vidaMaxima;
        barraVida.EstablecerVida(vida);
    }
}

    void Update()
    {
        float movimiento = 0;

        if (Input.GetKey(KeyCode.A))
            movimiento = -1;

        if (Input.GetKey(KeyCode.D))
            movimiento = 1;

        rb.linearVelocity = new Vector2(
            movimiento * velocidad,
            rb.linearVelocity.y
        );

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
        if (collision.gameObject.CompareTag("Ground"))
        {
            saltosRestantes = maxSaltos;
        }
    }

    public void RecibirDanio(int cantidad)
{
    vida -= cantidad;

    if (vida < 0)
        vida = 0;

    Debug.Log("Vida restante: " + vida);

    if (barraVida != null)
        barraVida.EstablecerVida(vida);

    if (vida <= 0)
    {
        vida = vidaMaxima;

        if (barraVida != null)
            barraVida.EstablecerVida(vida);

        GameManager.instancia.Respawn(gameObject);
    }
}
}