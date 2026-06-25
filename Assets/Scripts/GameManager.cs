using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("Checkpoint")]
    public Vector3 ultimoCheckpoint;

    [Header("Monedas")]
    public int monedas = 0;
    public TMP_Text textoMonedas;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ActualizarTextoMonedas();
    }

    // Guarda la posición inicial del jugador
    public void EstablecerInicio(Vector3 posicion)
    {
        if (ultimoCheckpoint == Vector3.zero)
        {
            ultimoCheckpoint = posicion;
        }
    }

    // Guarda la posición del último checkpoint
    public void ActualizarCheckpoint(Vector3 posicion)
    {
        ultimoCheckpoint = posicion;
        Debug.Log("Nuevo Checkpoint: " + ultimoCheckpoint);
    }

    // Respawn del jugador
    public void Respawn(GameObject jugador)
    {
        if (jugador == null)
            return;

        jugador.transform.position = ultimoCheckpoint;

        Debug.Log("Respawn realizado");
    }

    // Reinicia el checkpoint
    public void ReiniciarCheckpoint()
    {
        ultimoCheckpoint = Vector3.zero;
    }

    // Agrega monedas
    public void AgregarMonedas(int cantidad)
    {
        monedas += cantidad;

        ActualizarTextoMonedas();

        Debug.Log("Monedas: " + monedas);
    }

    // Actualiza el texto de monedas
    private void ActualizarTextoMonedas()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = monedas.ToString();
        }
    }
}