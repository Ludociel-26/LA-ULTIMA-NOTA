// using UnityEngine;

// public class FlashlightController : MonoBehaviour
// {
//     private Light flashlight;

//     void Start()
//     {
//         flashlight = GetComponent<Light>();
//         flashlight.enabled = true; // Linterna encendida por defecto
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.F))
//         {
//             flashlight.enabled = !flashlight.enabled; // Alternar linterna
//         }
//     }
// }
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    // Variables públicas para ajustar el aspecto de la linterna en el Inspector
    [Header("Configuración de Potencia")]
    public float intensidadMaxima = 20f;  // Para un efecto más potente
    public float alcanceMaximo = 70f;    // Distancia máxima a la que alumbra

    [Header("Referencias")]
    public Camera camaraJugador;        // ¡IMPORTANTE! Asigna aquí la cámara principal
    
    private Light flashlight;

    void Start()
    {
        // 1. Obtiene el componente Light
        flashlight = GetComponent<Light>();

        // 2. Configura los parámetros iniciales
        flashlight.intensity = intensidadMaxima;
        flashlight.range = alcanceMaximo;
        flashlight.enabled = true; // Linterna encendida por defecto

        // 3. Comprueba la referencia a la cámara si no fue asignada en el Inspector
        if (camaraJugador == null)
        {
            camaraJugador = Camera.main;
            if (camaraJugador == null)
            {
                Debug.LogError("La cámara del jugador no fue asignada ni se encontró la 'Main Camera'.");
            }
        }
    }

    void Update()
    {
        // --- 1. Alternar Linterna ---
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }

        // --- 2. Seguimiento de la Cámara (Dirección) ---
        // Este es el paso crucial para que la linterna mire donde mira el personaje.
        if (camaraJugador != null)
        {
            // La linterna toma la posición y la rotación (dirección) de la cámara.
            transform.position = camaraJugador.transform.position;
            transform.rotation = camaraJugador.transform.rotation;
        }
    }
}