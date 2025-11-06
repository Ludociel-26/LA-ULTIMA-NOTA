using UnityEngine;
using UnityEngine.SceneManagement;

// 🛑 CORRECCIÓN CLAVE: La clase debe heredar de MonoBehaviour
public class ListenHistory1 : MonoBehaviour 
{
    
    public float storyTime = 3f; // segundos que dura la intro
    public string nextScene = "IntroScene"; // nombre de la siguiente escena

    void Start()
    {
        // El método Invoke() ya estará disponible
        Invoke("LoadNextScene", storyTime);
    }

    public void LoadNextScene()
    {
        // 🛑 Nota Importante: Asegúrate de que "IntroScene" esté añadida en Build Settings.
        SceneManager.LoadScene(nextScene);
    }
}