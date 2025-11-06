// using UnityEngine;
// using UnityEngine.SceneManagement; // Necesario para cambiar de escena.

// public class PuertaGimnasio : MonoBehaviour
// {
//     // Variables para rastrear las llaves recogidas.
//     private bool tieneLlaveOficina = false;
//     private bool tieneLlaveLaboratorio = false;
//     private bool tieneLlaveBiblioteca = false;

//     // Nombre de la escena a la que se debe avanzar (¡Asegúrate que el nombre sea correcto!)
//     public string nombreSiguienteEscena = "Escena_Gimnasio";

//     // Función llamada por el script ItemPickup cuando una llave es recogida.
//     public void RecogerLlave(TipoLlave llaveRecogida)
//     {
//         switch (llaveRecogida)
//         {
//             case TipoLlave.Oficina:
//                 tieneLlaveOficina = true;
//                 Debug.Log("¡Llave de Oficina recogida!");
//                 break;
//             case TipoLlave.Laboratorio:
//                 tieneLlaveLaboratorio = true;
//                 Debug.Log("¡Llave de Laboratorio recogida!");
//                 break;
//             case TipoLlave.Biblioteca:
//                 tieneLlaveBiblioteca = true;
//                 Debug.Log("¡Llave de Biblioteca recogida!");
//                 break;
//         }

//         // Después de recoger cualquier llave, verifica si el puzle está completo.
//         VerificarPuzleCompleto();
//     }

//     // Verifica si se han recogido todas las llaves necesarias.
//     private void VerificarPuzleCompleto()
//     {
//         if (tieneLlaveOficina && tieneLlaveLaboratorio && tieneLlaveBiblioteca)
//         {
//             Debug.Log("¡PUZLE RESUELTO! La puerta del gimnasio ahora está desbloqueada.");
//             AbrirPuertaYAvanzar();
//         }
//     }

//     // Se activa cuando el jugador entra en contacto con el Collider de la puerta.
//     private void OnCollisionEnter(Collision collision)
//     {
//         // Asegúrate de que el Jugador tiene el Tag "Player" y que la Puerta NO es un Trigger.
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             if (tieneLlaveOficina && tieneLlaveLaboratorio && tieneLlaveBiblioteca)
//             {
//                 // Si el jugador choca con la puerta y tiene todas las llaves, avanza.
//                 AbrirPuertaYAvanzar();
//             }
//             else
//             {
//                 // Muestra un mensaje al jugador (puedes usar un UI Text).
//                 Debug.Log("Esta puerta requiere las 3 llaves: Oficina, Laboratorio y Biblioteca. ¡Sigue buscando!");
//             }
//         }
//     }

//     // Realiza la acción final del puzle.
//     private void AbrirPuertaYAvanzar()
//     {
//         // Opcional: Anima la puerta (la mueves, la rotas, o la destruyes).
//         Destroy(gameObject); // Opcional: Destruye la puerta para simular que desaparece.

//         // ¡Carga la siguiente escena!
//         SceneManager.LoadScene(nombreSiguienteEscena);
//     }
// }