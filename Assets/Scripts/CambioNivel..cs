using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    [Header("Escena siguiente")]
    public string nombreEscena;

    [Header("Retraso antes del cambio")]
    public float tiempoEspera = 1f;

    private bool cambiar = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !cambiar)
        {
            cambiar = true;

            Debug.Log("Nivel completado");

            Invoke(nameof(CargarNivel), tiempoEspera);
        }
    }

    void CargarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscena);
    }
}