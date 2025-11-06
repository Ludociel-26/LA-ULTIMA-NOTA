using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public float storyTime = 35f; // segundos que dura la intro
    public string nextScene = "Puzzle1Scene"; // nombre de la siguiente escena

    void Start()
    {
        // Cambiar de escena automáticamente después de cierto tiempo
        Invoke("LoadNextScene", storyTime);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
