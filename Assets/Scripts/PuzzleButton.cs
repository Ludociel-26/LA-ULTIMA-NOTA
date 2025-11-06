using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    // 🔹 Referencia al PuzzleManager
    public PuzzleManager puzzleManager;

    private bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;

            // 🔸 Simula presión del botón (baja un poco)
            transform.position -= new Vector3(0, 0.1f, 0);

            // 🔸 Cambia color del botón para feedback visual
            GetComponent<Renderer>().material.color = Color.green;

            // 🔸 Notifica al PuzzleManager
            puzzleManager.SwitchActivated();

            Debug.Log($"{gameObject.name} presionado!");
        }
    }
}
