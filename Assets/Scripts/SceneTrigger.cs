// using UnityEngine;

// public class SceneTrigger : MonoBehaviour
// {
//     public string sceneToLoad;
//     private bool triggered = false;
//     private void OnTriggerEnter(Collider other)
//     {
//         if (triggered) return;
//         if (other.CompareTag("Player"))
//         {
//             triggered = true;
//             FindObjectOfType<SceneLoader>().CargarEscenaPorNombre(sceneToLoad);
//         }
//     // 
// }
