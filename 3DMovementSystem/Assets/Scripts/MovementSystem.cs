using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystemBUGGED : MonoBehaviour
{
    public Vector3 moveForward = new Vector3(1f, 0f, 0f);
    public Vector3 moveSideways = new Vector3(0f, 0f, 1f);
    public float moveSpeed = 5f;
    public Vector3 jump = new Vector3(0f, 1f, 0f);
    public float jumpHeight = 5f;
    public float lookSpeed = 2f;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalRotation;
    // Start is called before the first frame update
    void Start()
    {
        jumpHeight = 5f;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // input keys for movemnt
        if (Input.GetKey(KeyCode.W))

        {
            Debug.Log("Hello");
            Vector3 movement = moveForward * moveSpeed * Time.deltaTime;
            transform.position -= movement;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = moveSideways * moveSpeed * Time.deltaTime;
            transform.position -= movement;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = moveSideways * moveSpeed * Time.deltaTime;
            transform.position += movement;
        }
        if (Input.GetKey(KeyCode.S))

        {
            Vector3 movement = moveForward * moveSpeed * Time.deltaTime;
            transform.position += movement;

        }
     //   if (Input.GetKey(KeyCode.Space))
     
     //   {
       //     Vector3 movement = jump * jumpHeight * Time.deltaTime;
       //     transform.position += movement;
     //   }

        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Clamp up and down rotation

        Camera camera = Camera.main;
        camera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
        moveDirection.y -= 9.81f * Time.deltaTime; // Gravity
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
