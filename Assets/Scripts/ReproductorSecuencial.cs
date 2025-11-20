using UnityEngine;
using System.Collections; // Necesario para usar Coroutine

public class ReproductorSecuencial : MonoBehaviour
{
    [Header("Configuración de Audio")]
    [Tooltip("El AudioSource que reproducirá los clips. ¡Debe estar en este objeto!")]
    private AudioSource fuenteDeAudio;
    
    [Header("Clips de Secuencia")]
    [Tooltip("Arrastra los clips de audio en el orden en que quieres que suenen.")]
    public AudioClip[] clipsDeSecuencia;

    // Se llama automáticamente al inicio
    void Start()
    {
        // Asegúrate de tener el componente AudioSource adjunto
        fuenteDeAudio = GetComponent<AudioSource>();
        if (fuenteDeAudio == null)
        {
            Debug.LogError("Falta el componente AudioSource en este objeto.");
            return;
        }

        // Inicia la reproducción de la secuencia
        IniciarSecuencia();
    }

    public void IniciarSecuencia()
    {
        StartCoroutine(ReproducirClipsEnOrden());
    }

    private IEnumerator ReproducirClipsEnOrden()
    {
        if (clipsDeSecuencia == null || clipsDeSecuencia.Length == 0) yield break;

        foreach (AudioClip clip in clipsDeSecuencia)
        {
            if (clip != null)
            {
                // 1. Asigna el clip actual al AudioSource
                fuenteDeAudio.clip = clip;

                // 2. Reproduce el clip
                fuenteDeAudio.Play();

                // 3. Espera exactamente la duración del clip para el siguiente
                yield return new WaitForSeconds(clip.length);
            }
        }
        
        Debug.Log("Secuencia de audio finalizada.");
    }
}