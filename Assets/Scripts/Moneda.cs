using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moneda recogida");

            GameManager.instancia.AgregarMonedas(valor);

            Destroy(gameObject);
        }
    }
}