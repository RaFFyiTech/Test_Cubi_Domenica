using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        Vector3 inputVector = Vector3.zero; // Inizializzazione Bussola, se deve essere mosso solo destra sinistra, avanti indietro e salto, quindi x,y quindi scrivere Vector2

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) inputVector.y = 1;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) inputVector.y = -1;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) inputVector.x = -1;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) inputVector.x = 1;
        if (Keyboard.current.spaceKey.isPressed) inputVector.z = 1;

        Vector3 movement = new Vector3(inputVector.x, inputVector.z, inputVector.y); // Inizializzazione Bussola, se deve essere mosso solo destra sinistra, avanti indietro e salto, quindi x,y quindi scrivere Vector2

        rb.AddForce(movement * speed);
    }
}