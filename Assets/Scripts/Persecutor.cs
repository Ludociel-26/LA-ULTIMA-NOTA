using UnityEngine;
using UnityEngine.AI; // Necesario para usar el NavMesh Agent

public class Persecutor : MonoBehaviour
{
    [Header("Configuración del Agente")]
    public float rangoDePersecucion = 20f; // Distancia a la que empieza a perseguir
    public float velocidadDePersecucion = 3.5f;
    
    [Header("Referencias")]
    private Transform objetivo; // El Transform del jugador
    private NavMeshAgent agente;
    private const string PlayerTag = "Player"; // La etiqueta de tu jugador

    void Start()
    {
        // 1. Obtiene la referencia al jugador por Tag
        GameObject jugadorGO = GameObject.FindWithTag(PlayerTag);
        if (jugadorGO != null)
        {
            objetivo = jugadorGO.transform;
        }

        // 2. Obtiene el componente NavMeshAgent
        agente = GetComponent<NavMeshAgent>();
        
        // 3. Configura la velocidad inicial
        if (agente != null)
        {
            agente.speed = velocidadDePersecucion;
        }
    }

    void Update()
{
    if (objetivo == null || agente == null) return;

    // Aseguramos que el agente esté habilitado para operar
    if (!agente.enabled) 
    {
        agente.enabled = true;
    }

    float distancia = Vector3.Distance(transform.position, objetivo.position);

    // Si el jugador está dentro del rango de persecución
    if (distancia <= rangoDePersecucion)
    {
        // El agente está dentro del rango, entonces debe perseguir
        agente.isStopped = false; // Asegura que no esté detenido
        agente.SetDestination(objetivo.position);
    }
    else
    {
        // 🛑 LÓGICA CORREGIDA PARA DETENCIÓN SEGURA:
        // Si el agente está fuera del rango, detenemos el movimiento.
        // Usamos isStopped = true, pero solo si el agente no está pendiente de ser desactivado.
        
        if (agente.hasPath) // Solo si ya estaba moviéndose o tenía un camino
        {
            // Usa isStopped para una detención temporal y segura.
            agente.isStopped = true; 
        } 
        else if (agente.remainingDistance < 0.1f)
        {
            // Si estaba quieto cerca de su destino, simplemente lo dejamos quieto
            agente.isStopped = true;
        }
        
        // Alternativamente, puedes simplemente limpiar el destino:
        // agente.ResetPath(); 
    }
}
}