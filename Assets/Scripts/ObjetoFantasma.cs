using UnityEngine;
using System.Collections; // Necesario para usar Coroutine

public class ObjetoFantasma : MonoBehaviour
{

    [Header("Objeto a controlar")]
    public GameObject objetoADisplay;

    [Header("Configuración")]
    public float tiempoVisible = 0.5f; // Duración de la aparición (medio segundo)
    public float tiempoInactivo = 5f;  // Tiempo antes de que se pueda reactivar

    private bool puedeActivar = true;

    void Start()
    {
        // 🛑 CRUCIAL: Asegura que el objeto esté invisible al inicio
        if (objetoADisplay != null)
        {
            objetoADisplay.SetActive(false);
        }
    }

    public void ActivarAparicion()
    {
        if (puedeActivar)
        {
            // Bloquea la activación para evitar spam
            puedeActivar = false;
            
            // Inicia la Coroutine para la secuencia de aparición y desaparición
            StartCoroutine(SecuenciaFantasma());
        }
    }

    IEnumerator SecuenciaFantasma()
    {
        if (objetoADisplay == null) yield break;

        // 1. APARECER
        objetoADisplay.SetActive(true);
        
        // 2. Esperar el tiempo de visibilidad
        yield return new WaitForSeconds(tiempoVisible);

        // 3. DESAPARECER
        objetoADisplay.SetActive(false);
        
        // 4. Esperar el tiempo de enfriamiento
        yield return new WaitForSeconds(tiempoInactivo);
        
        puedeActivar = true;
    }
}