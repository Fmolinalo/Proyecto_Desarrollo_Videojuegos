using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Estado del Checkpoint")]
    public bool checkpointActivo = false;

    [Header("Sprites")]
    public Sprite spriteInactivo;
    public Sprite spriteActivo;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && spriteInactivo != null)
        {
            spriteRenderer.sprite = spriteInactivo;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!checkpointActivo && other.CompareTag("Player"))
        {
            checkpointActivo = true;

            if (spriteRenderer != null && spriteActivo != null)
            {
                spriteRenderer.sprite = spriteActivo;
            }

            // Guarda la posición del checkpoint
            GameManager.instancia.ActualizarCheckpoint(transform.position);

            Debug.Log("Checkpoint activado");
        }
    }
}