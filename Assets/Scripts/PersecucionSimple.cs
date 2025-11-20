using UnityEngine;

public class PersecucionSimple : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidadMovimiento = 4.0f; // Velocidad de persecución
    public float rangoDePersecucion = 20.0f; // Distancia a la que inicia
    public float distanciaDeParada = 1.5f;   // Distancia a la que se detiene
    public float velocidadRotacion = 5.0f;   // Qué tan rápido gira

    [Header("Evitar Paredes")]
    public float distanciaEvitar = 1.0f;  // Distancia para detectar paredes
    public LayerMask layerParedes;        // ¡CRUCIAL! Capa que contiene las paredes

    [Header("Referencias")]
    private Transform objetivo;
    private const string PlayerTag = "Player";

    void Start()
    {
        // Busca al jugador por Tag al inicio
        GameObject jugadorGO = GameObject.FindWithTag(PlayerTag);
        if (jugadorGO != null)
        {
            objetivo = jugadorGO.transform;
        }
    }

    void Update()
    {
        if (objetivo == null) return;

        Vector3 direccionAlObjetivo = objetivo.position - transform.position;
        float distanciaActual = direccionAlObjetivo.magnitude;

        // 1. Verificar si el jugador está en rango
        if (distanciaActual <= rangoDePersecucion)
        {
            // 2. Gira para mirar al objetivo
            RotarHaciaObjetivo(direccionAlObjetivo);

            // 3. Verifica colisiones antes de moverse
            if (distanciaActual > distanciaDeParada && !HayParedesDelante())
            {
                // 4. Moverse hacia adelante
                transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);
            }
        }
    }

    private void RotarHaciaObjetivo(Vector3 direccion)
    {
        // Ignora el eje Y (vertical) para que solo rote en el suelo
        Quaternion rotacionDeseada = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        
        // Aplica una rotación suave (Lerp)
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.deltaTime * velocidadRotacion);
    }
    
    private bool HayParedesDelante()
    {
        // Lanza un Raycast hacia adelante para detectar obstáculos
        // Si golpea algo en la capa 'layerParedes' dentro de la distanciaEvitar, devuelve true
        return Physics.Raycast(transform.position, transform.forward, distanciaEvitar, layerParedes);
    }
}