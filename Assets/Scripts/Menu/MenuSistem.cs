using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSistem : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void SalirJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}