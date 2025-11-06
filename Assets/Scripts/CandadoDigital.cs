// using UnityEngine;
// using UnityEngine.SceneManagement; 

// public class CandadoDigital : MonoBehaviour
// {
//     private const string CODIGO_SECRETO = "1234"; 
    
//     public string nombreSiguienteEscena = "Escena_Gimnasio";

// // 🛑 NUEVA REFERENCIA: Arrastra el panel de la UI aquí.
//     [Header("UI del Candado")]
//     public GameObject uiPanelCandado; 

//     private const string PlayerTag = "Player"; // Etiqueta para el jugador
//     private string codigoActual = ""; 
//     private bool estaAbierto = false;
//     private bool mostrandoInput = false; // Nueva bandera para saber si activar el input
    
//     // Eliminamos 'jugadorCamara', 'alcanceInteraccion', y 'teclaInteractuar'.
// private TextMeshProUGUI textoInput; // Si quieres mostrar el código en la UI
//    void Update()
//     {
//         // Solo detecta números si el input está mostrando la UI Y la puerta no está abierta.
//         if (mostrandoInput && !estaAbierto)
//         {
//             DetectarInputNumerico();
            
//             // 🛑 NUEVA LÓGICA: Desactivar la UI si el jugador presiona ESC
//             if (Input.GetKeyDown(KeyCode.Escape))
//             {
//                 DesactivarUI();
//             }
//         }
//     }

//     // **************************************************
//     // 🛑 NUEVOS MÉTODOS: Detección por Proximidad (Trigger)
//     // **************************************************

//     // 1. Cuando el jugador entra en el área del candado
//   private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag(PlayerTag))
//         {
//             // Solo activar si no está ya abierto
//             if (!estaAbierto)
//             {
//                 ActivarUI();
//             }
//         }
//     }

//     // 2. Cuando el jugador se aleja del área del candado
// private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag(PlayerTag))
//         {
//             DesactivarUI();
//         }
//     }

//     // **************************************************
//     // Lógica de Ingreso (la misma, pero ahora depende de 'jugadorCerca')
//     // **************************************************

//     private void DetectarInputNumerico()
//     {
//         for (int i = 0; i <= 9; i++)
//         {
//             if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + i)) || 
//                 Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Keypad" + i)))
//             {
//                 codigoActual += i.ToString();
//                 Debug.Log("Código: " + codigoActual + " (Longitud: " + codigoActual.Length + ")");
                
//                 if (codigoActual.Length == 4)
//                 {
//                     VerificarCodigo();
//                 }
//                 else if (codigoActual.Length > 4)
//                 {
//                     codigoActual = "";
//                     Debug.Log("Código muy largo. Reiniciando...");
//                 }
//                 return;
//             }
//         }
//     }

//   private void VerificarCodigo()
//     {
//         if (codigoActual == CODIGO_SECRETO)
//         {
//             estaAbierto = true;
//             Debug.Log("¡CÓDIGO CORRECTO! La puerta está abierta. Avanza.");
            
//             // 🛑 CORRECCIÓN 2: Asegúrate de desactivar la UI al abrirse
//             if (uiPanelCandado != null)
//             {
//                 uiPanelCandado.SetActive(false);
//             }
            
//             AbrirPuertaYAvanzar();
//         }
//         else
//         {
//             Debug.Log("CÓDIGO INCORRECTO: " + codigoActual);
//             codigoActual = ""; // Limpia el input para otro intento
//         }
//     }

//     private void AbrirPuertaYAvanzar()
//     {
//         // Debug.Log("Avanzando a la siguiente escena...");
//         Destroy(gameObject); 
//         SceneManager.LoadScene(nombreSiguienteEscena);
//     }
// }
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class CandadoDigital : MonoBehaviour
{
    private const string CODIGO_SECRETO = "1234"; 
    public string nombreSiguienteEscena = "Escena_Gimnasio";

    [Header("UI del Candado")]
    public GameObject uiPanelCandado; 
    public TMP_InputField inputFieldCodigo;

    private const string PlayerTag = "Player";
    private string codigoActual = ""; 
    private bool estaAbierto = false;
    private bool mostrandoInput = false; 
    
    // 🛑 CORRECCIÓN: Declaramos la variable que faltaba
    private TextMeshProUGUI textoInput; // Si quieres mostrar el código en la UI
    
    // Puedes usar Start() para obtener la referencia al texto de entrada si lo tienes

    void Update()
    {
        // Solo detecta números si el input está mostrando la UI Y la puerta no está abierta.
        if (mostrandoInput && !estaAbierto)
        {
            DetectarInputNumerico();
            
            // 🛑 NUEVA LÓGICA: Desactivar la UI si el jugador presiona ESC
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DesactivarUI();
            }
        }
    }

    // **************************************************
    // Detección por Proximidad (Trigger)
    // **************************************************

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            // Solo activar si no está ya abierto
            if (!estaAbierto)
            {
                ActivarUI();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            DesactivarUI();
        }
    }
    
    // MÉTODOS DE ACTIVACIÓN/DESACTIVACIÓN REUSABLES
    private void ActivarUI()
    {
         if (uiPanelCandado != null)
         {
             uiPanelCandado.SetActive(true);
             // Bloquea el movimiento del personaje si es un juego de terror (opcional)
             Time.timeScale = 0f; 
         }
         mostrandoInput = true;
         codigoActual = "";
    }
    
    private void DesactivarUI()
    {
        if (uiPanelCandado != null)
        {
            uiPanelCandado.SetActive(false);
            // Reanuda el juego (opcional)
            Time.timeScale = 1f; 
        }
        mostrandoInput = false;
        codigoActual = "";
    }


    // **************************************************
    // Lógica de Ingreso
    // **************************************************

    private void DetectarInputNumerico()
{
    for (int i = 0; i <= 9; i++)
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + i)) || 
            Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Keypad" + i)))
        {
            codigoActual += i.ToString();

            // 💡 ACTUALIZACIÓN CLAVE: Muestra el código en la UI
            if (inputFieldCodigo != null) 
            {
                inputFieldCodigo.text = codigoActual;
            }

            if (codigoActual.Length == CODIGO_SECRETO.Length)
            {
                VerificarCodigo();
            }
            else if (codigoActual.Length > CODIGO_SECRETO.Length)
            {
                codigoActual = ""; 
                // 💡 Limpia el texto en la UI si el código es muy largo
                if (inputFieldCodigo != null) { inputFieldCodigo.text = ""; } 
                Debug.Log("Código muy largo. Reiniciando...");
            }
            return;
        }
    }
}

    private void VerificarCodigo()
    {
        if (codigoActual == CODIGO_SECRETO)
        {
            estaAbierto = true;
            Debug.Log("¡CÓDIGO CORRECTO! La puerta está abierta. Avanza.");
            
            // 🛑 CORRECCIÓN: Asegúrate de que la UI se oculte y el juego avance
            DesactivarUI(); 
            AbrirPuertaYAvanzar();
        }
        else
        {
            Debug.Log("CÓDIGO INCORRECTO: " + codigoActual);
            codigoActual = ""; // Limpia el input para otro intento
            // if (textoInput != null) { textoInput.text = ""; }
        }
    }

    private void AbrirPuertaYAvanzar()
    {
        // Esta función SOLO se llama si el código es CORRECTO.
        SceneManager.LoadScene(nombreSiguienteEscena);
        
        // 🛑 CORRECCIÓN: Destruir el objeto DESPUÉS de cargar la escena
        // O más seguro: no lo destruyas aquí, ya que la escena se cambiará.
        // Si necesitas que la puerta desaparezca ANTES de avanzar:
        Destroy(gameObject); 
    }
}