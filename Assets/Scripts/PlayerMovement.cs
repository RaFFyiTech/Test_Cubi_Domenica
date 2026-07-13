using UnityEngine;
// 1. DOBBIAMO IMPORTARE IL NUOVO PACCHETTO DI INPUT
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Cattura e nasconde il mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Nel nuovo Input System, per leggere un tasto al volo (come ESC) si fa così:
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Se riclicchi sullo schermo, ricattura il mouse
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void FixedUpdate()
    {
        // 2. LEGGIAMO I TASTI WASD / FRECCE CON IL NUOVO SISTEMA
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) moveVertical = 1f;
            if (Keyboard.current.sKey.isPressed) moveVertical = -1f;
            if (Keyboard.current.aKey.isPressed) moveHorizontal = -1f;
            if (Keyboard.current.dKey.isPressed) moveHorizontal = 1f;
        }

        Vector3 movement = Vector3.zero;

        if (cameraTransform != null)
        {
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            movement = (forward * moveVertical) + (right * moveHorizontal);
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }

        // Applichiamo la velocità tramite fisica
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);

        // Rotazione fluida verso la direzione di cammino
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f));
        }
    }
}