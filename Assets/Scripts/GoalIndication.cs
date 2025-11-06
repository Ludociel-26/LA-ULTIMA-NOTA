using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro
using System.Collections;

public class GoalIndication : MonoBehaviour
{
    [Header("Configuración de Tiempo")]
    public float tiempoVisibleGrande = 5f; // Tiempo que estará en el centro de la pantalla
    public float tiempoTransicion = 1.5f;   // Duración de la animación de encogimiento/movimiento

    [Header("Configuración de Posición")]
    public Vector3 escalaObjetivo = new Vector3(0.5f, 0.5f, 1f); // Reducir el tamaño a la mitad
    public Vector3 posicionObjetivo = new Vector3(100, -100, 0); // Posición final (ej. esquina inferior derecha)
    
    // Componentes
    private RectTransform rectTransform;
    private TextMeshProUGUI textoComponente;
    private Vector3 escalaInicial;
    private Vector3 posicionInicial;

    void Start()
    {
        // 1. Obtener componentes del Panel PADRE (donde está el script)
        rectTransform = GetComponent<RectTransform>();
        
        // 🛑 CORRECCIÓN CLAVE: Obtener el componente de texto del objeto HIJO.
        // Asumiendo que el texto es un hijo directo del Panel.
        textoComponente = GetComponentInChildren<TextMeshProUGUI>();

        escalaInicial = rectTransform.localScale;
        posicionInicial = rectTransform.anchoredPosition3D; 

        // 2. Iniciar el temporizador
        Invoke("StartTransition", tiempoVisibleGrande);
    }

    private void StartTransition()
    {
        // Inicia la Corrutina para animar el movimiento y el tamaño
        StartCoroutine(TransitionRoutine());
    }

    System.Collections.IEnumerator TransitionRoutine()
    {
        float tiempoTranscurrido = 0f;
        
        // Guardar valores antes de la transición
        Vector3 inicioEscala = rectTransform.localScale;
        Vector3 inicioPosicion = rectTransform.anchoredPosition3D;
        Color colorInicial = textoComponente.color;

        while (tiempoTranscurrido < tiempoTransicion)
        {
            // Calcular el progreso de la transición (0.0 a 1.0)
            tiempoTranscurrido += Time.deltaTime;
            float t = tiempoTranscurrido / tiempoTransicion;
            
            // Suavizado (opcional, para que la animación se sienta mejor)
            float tSuavizado = Mathf.SmoothStep(0.0f, 1.0f, t); 

            // 1. Animación de Escala
            rectTransform.localScale = Vector3.Lerp(inicioEscala, escalaObjetivo, tSuavizado);
            
            // 2. Animación de Posición
            rectTransform.anchoredPosition3D = Vector3.Lerp(inicioPosicion, posicionObjetivo, tSuavizado);
            
            // 3. Desvanecer ligeramente el texto mientras se mueve (opcional)
            Color colorObjetivo = new Color(colorInicial.r, colorInicial.g, colorInicial.b, 0.8f); // 80% opacidad
            textoComponente.color = Color.Lerp(colorInicial, colorObjetivo, tSuavizado);

            yield return null; // Espera al siguiente frame
        }

        // Asegurarse de que termine en el estado final
        rectTransform.localScale = escalaObjetivo;
        rectTransform.anchoredPosition3D = posicionObjetivo;
    }
}