using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    private int switchesActivated = 0;
    public int totalSwitches = 3; // total de interruptores
    public string nextSceneName = "Puzzle2Scene"; // la siguiente escena a cargar

    public void SwitchActivated()
    {
        switchesActivated++;

        Debug.Log($"Interruptores activados: {switchesActivated}/{totalSwitches}");

        if (switchesActivated >= totalSwitches)
        {
            Debug.Log("¡Puzzle completado! Cargando siguiente escena...");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
