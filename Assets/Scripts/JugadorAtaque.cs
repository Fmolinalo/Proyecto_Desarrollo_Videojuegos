using UnityEngine;

public class JugadorAtaque : MonoBehaviour
{
    [Header("Ataque")]
    public int danio = 25;
    public float rangoAtaque = 1.5f;
    public float distanciaAtaque = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        // Determina hacia dónde mira el jugador
        float direccion = transform.localScale.x >= 0 ? 1f : -1f;

        Vector2 puntoAtaque = new Vector2(
            transform.position.x + (direccion * distanciaAtaque),
            transform.position.y
        );

        Collider2D[] enemigos = Physics2D.OverlapCircleAll(puntoAtaque, rangoAtaque);

        Debug.Log("Enemigos encontrados: " + enemigos.Length);

        foreach (Collider2D col in enemigos)
        {
            Debug.Log("Detectado: " + col.name);

            Enemigo enemigo = col.GetComponent<Enemigo>();

            if (enemigo != null)
            {
                Debug.Log("Daño aplicado");

                enemigo.RecibirDanio(danio);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        float direccion = transform.localScale.x >= 0 ? 1f : -1f;

        Vector2 puntoAtaque = new Vector2(
            transform.position.x + (direccion * distanciaAtaque),
            transform.position.y
        );

        Gizmos.DrawWireSphere(puntoAtaque, rangoAtaque);
    }
}