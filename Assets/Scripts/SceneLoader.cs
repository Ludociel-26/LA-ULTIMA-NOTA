using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void CargarSiguienteEscena()
    {
        int idx = SceneManager.GetActiveScene().buildIndex;
        if (idx + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(idx + 1);
    }

    // public void CargarEscenaPorNombre(string nombre)
    // {
    //     SceneManager.LoadScene(nombre);
    // }

    public void ReiniciarEscenaActual()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
