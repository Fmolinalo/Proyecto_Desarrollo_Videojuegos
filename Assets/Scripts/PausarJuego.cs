using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    [Header("Panel del menú de pausa")]
    public GameObject menuPause;

    private bool juegoPausado = false;

    void Start()
    {
        if (menuPause != null)
        {
            menuPause.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        if (menuPause != null)
            menuPause.SetActive(true);

        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        if (menuPause != null)
            menuPause.SetActive(false);

        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        Application.Quit();

        Debug.Log("Salir del juego");
    }
}