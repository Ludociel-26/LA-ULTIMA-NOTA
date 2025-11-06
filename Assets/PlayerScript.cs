using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Variables
    private float speed = 15f;
    public float MinSpeed = 15f;
    public float MaxSpeed = 25f;
    public float JumpForce = 6f;

    //Camara
    public float Sensibility = 2f;
    public float LimitX = 45;
    public Transform cam;

    private float rotationX;
    private float rotationY;

    public bool IsGraunder;
    private Rigidbody rb;
    private Vector3 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // 🛑 AJUSTE CLAVE: Congelar la rotación para evitar que el Rigidbody se caiga
        rb.freezeRotation = true;
    }


    void Update()
    {
        //Movimiento
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

// Almacena el vector de movimiento, pero no lo aplicamos aún
        movementInput = new Vector3(x, 0, y);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = MaxSpeed;
        }
        else
        {
            speed = MinSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        // transform.Translate(new Vector3(x, 0, y) * Time.deltaTime * speed);

        //Camara
        rotationX += -Input.GetAxis("Mouse Y") * Sensibility;
        rotationX = Mathf.Clamp(rotationX, -LimitX, LimitX);
        cam.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * Sensibility, 0);

// if (Input.GetKeyDown(KeyCode.E))
// {
//     Ray ray = new Ray(cam.position, cam.forward);
//     if (Physics.Raycast(ray, out RaycastHit hit, 3f))
//     {
//         var button = hit.collider.GetComponent<PuzzleButton>();
//         if (button != null)
//         {
//             button.Press();
//         }
//     }
// }

    }

    // 🌟 NUEVA FUNCIÓN: FixedUpdate se usa para operaciones de física (como Rigidbody)
    void FixedUpdate()
    {
        // 1. Calcular el movimiento deseado en la dirección del personaje
        Vector3 movimientoDeseado = transform.TransformDirection(movementInput) * speed;
        
        // 2. Mantener la velocidad actual del Rigidbody en el eje Y (para no afectar la gravedad/salto)
        movimientoDeseado.y = rb.linearVelocity.y; 

        // 3. Aplicar el movimiento usando la velocidad del Rigidbody (MÁS SEGURO)
        // Esto permite que el Rigidbody choque correctamente con otros colliders.
        rb.linearVelocity = movimientoDeseado;
        
        // El método rb.MovePosition es una alternativa, pero rb.velocity suele ser mejor
        // para el control de personajes.
    }

    public void Jump()
    {
        if (IsGraunder)
        {
             rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGraunder = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGraunder = false;
        }
    }
}
