using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetoVictoria : MonoBehaviour
{
    [Header("Configuración de Escenas")]
    public string escenaVictoria = "Escena_Creditos"; 
    
    [Tooltip("El nombre de la etiqueta que debe activar la victoria (debería ser 'Player').")]
    private const string PlayerTag = "Player";
    
    private bool objetivoAlcanzado = false;

    // Se activa cuando otro collider (el jugador) entra en el área del Trigger
    private void OnTriggerEnter(Collider other)
    {
        // 1. Verifica que el objeto que colisiona sea el jugador y que no se haya ganado ya
        if (other.CompareTag(PlayerTag) && !objetivoAlcanzado)
        {
            objetivoAlcanzado = true;
            FinalVictoria();
        }
    }

    private void FinalVictoria()
    {
        Debug.Log("¡OBJETIVO ALCANZADO! Felicitaciones, has ganado.");
        
        // Carga la escena de los créditos o la siguiente escena de victoria
        SceneManager.LoadScene(escenaVictoria);
    }
}