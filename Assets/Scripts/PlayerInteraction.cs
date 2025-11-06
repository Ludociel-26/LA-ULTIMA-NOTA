// using UnityEngine;

// public class PlayerInteraction : MonoBehaviour
// {
//     public float maxDistance = 10f; // Distancia máxima para que el rayo funcione
//     private Camera jugadorCamara;

//     void Start()
//     {
//         // Asegúrate de que tu cámara tiene el Tag 'MainCamera'
//         jugadorCamara = Camera.main; 
//         if (jugadorCamara == null)
//         {
//             Debug.LogError("Error: Necesitas una cámara con el tag 'MainCamera'.");
//         }
//     }

//     void Update()
//     {
//         // 1. Detectar el clic izquierdo del ratón.
//         if (Input.GetMouseButtonDown(0)) // 0 es el botón izquierdo del ratón
//         {
//             if (jugadorCamara == null) return;

//             // 2. Crear un Rayo desde la posición del mouse en la pantalla hacia el mundo 3D.
//             Ray rayo = jugadorCamara.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hit;

//             // 3. Lanza el rayo para detectar colisiones.
//             if (Physics.Raycast(rayo, out hit, maxDistance))
//             {
//                 // 4. Intenta obtener el componente ItemPickup del objeto golpeado.
//                 ItemPickup llave = hit.collider.GetComponent<ItemPickup>();

//                 // 5. Si el objeto tiene el script ItemPickup (es una llave)...
//                 if (llave != null)
//                 {
//                     Debug.Log("¡Clic Exitoso! Llave detectada: " + hit.collider.gameObject.name); 
//                     llave.Recoger(); // Llama a la función de recolección de la llave.
//                 }
//             }
//         }
//     }
// }