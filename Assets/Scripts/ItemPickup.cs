// using UnityEngine;

// // Define los diferentes tipos de llaves que puede haber.
// public enum TipoLlave { Oficina, Laboratorio, Biblioteca }

// public class ItemPickup : MonoBehaviour
// {
//     public TipoLlave tipoDeLlave; // Asigna esto en el Inspector de cada llave.
//     private PuertaGimnasio puertaGimnasio; // Referencia al script de la puerta.

//     void Start()
//     {
//         // Busca el script de la puerta en la escena para comunicarle la llave.
//         puertaGimnasio = FindAnyObjectByType<PuertaGimnasio>();

//         if (puertaGimnasio == null)
//         {
//             Debug.LogError("El script PuertaGimnasio no se encuentra en la escena. ¡Asegúrate de que la Puerta_Gimnasio lo tiene!");
//         }
//     }

//     // Se activa cuando otro Collider entra en contacto con el Trigger de la llave.
//     // private void OnTriggerEnter(Collider other)
//     // {
//     //     // Solo reacciona si el objeto que entra es el Jugador.
//     //     // Asegúrate de que tu Jugador tiene el Tag "Player".
//     //     if (other.CompareTag("Player"))
//     //     {
//     //         // 1. Informa al puzle de la puerta que la llave ha sido recogida.
//     //         if (puertaGimnasio != null)
//     //         {
//     //             puertaGimnasio.RecogerLlave(tipoDeLlave);
//     //         }

//     //         // 2. Destruye el objeto llave para simular que ha sido recogida.
//     //         Destroy(gameObject); 
//     //     }
//     // }
//     // NUEVA FUNCIÓN PÚBLICA: Llamada desde el script del Jugador
//     public void Recoger()
//     {
//         // Este código ahora realiza la lógica de recolección.
//         if (puertaGimnasio != null)
//         {
//             // 1. Informa a la puerta.
//             puertaGimnasio.RecogerLlave(tipoDeLlave);
//         }

//         // 2. Destruye la llave.
//         Destroy(gameObject);
//     }
// }