using UnityEngine;
using UnityEngine.SceneManagement;

public class EncuentroEstatico : MonoBehaviour
{
    [Header("Configuracion de Escenas")]
    public string escenaVictoria = "Escena_Creditos"; 
    public string escenaMuerte = "Escena_Game_Over";

    [Header("Efectos de Jumpscare")]
    public AudioSource sonidoJumpscare; // Referencia al componente de sonido
    public GameObject objetoDeSusto;    // Una imagen o modelo que aparece brevemente
    public float duracionSusto = 0.5f;   // Medio segundo para el susto

    private bool eventoActivado = false;
    private const string PlayerTag = "Player";
    
    // El fantasma solo debe tener este script y un Collider con Is Trigger marcado.

    private void OnTriggerEnter(Collider other)
    {
        // Solo reacciona si es el jugador y si el evento no ha ocurrido antes
        if (other.CompareTag(PlayerTag) && !eventoActivado)
        {
            eventoActivado = true;
            
            // Inicia la secuencia de terror y castigo
            StartCoroutine(SecuenciaEncuentroFinal());
        }
    }

    System.Collections.IEnumerator SecuenciaEncuentroFinal()
    {
        // 1. Desactivar el Collider (para evitar activaciones dobles)
        GetComponent<Collider>().enabled = false;
        
        // 2. Ejecutar el Susto (Jumpscare)
        if (objetoDeSusto != null) 
        {
            objetoDeSusto.SetActive(true);
        }
        if (sonidoJumpscare != null)
        {
            sonidoJumpscare.Play();
        }

        // 3. Esperar la duración del susto
        yield return new WaitForSeconds(duracionSusto);
        
        // 4. Ocultar el objeto de susto
        if (objetoDeSusto != null)
        {
            objetoDeSusto.SetActive(false);
        }

        // 5. Decisión final: Muerte o Avance
        
        // OPCION A: Muerte Inevitable (para un final más aterrador)
        FinalMuerte();
        
        // OPCION B: Avance Directo (si solo es un obstáculo superado)
        // FinalVictoria(); 
    }
    
    private void FinalMuerte()
    {
        Debug.Log("FIN DEL JUEGO: Atrapado por el fantasma en el exterior.");
        SceneManager.LoadScene(escenaMuerte);
    }
    
    private void FinalVictoria()
    {
        Debug.Log("Avance a la siguiente escena.");
        SceneManager.LoadScene(escenaVictoria);
    }
}