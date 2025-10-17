using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = true; // Linterna encendida por defecto
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled; // Alternar linterna
        }
    }
}
