using UnityEngine;

public class CamaraController : MonoBehaviour
{
    [Header("Configuración de la Cámara")]

    public Transform objetivo;

    [Range(0.01f, 1f)]
    public float velocidadCamara = 0.025f;

    public Vector3 desplazamiento = new Vector3(1.72f, 0f, -10f);

    void LateUpdate()
    {
        if (objetivo == null)
            return;

        Vector3 posicionDeseada = objetivo.position + desplazamiento;

        transform.position = Vector3.Lerp(
            transform.position,
            posicionDeseada,
            velocidadCamara
        );
    }
}