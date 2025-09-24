using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public CharacterController controller;

    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    public float gravity = -9.81f;
    public Vector3 velocity;

    public Vector3 spawnPoint;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Mouse Camera Controls
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        //Player Movement Controls
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);

        //gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //small negative value to keep player grounded
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(2f * -gravity * 1.5f); //1.5 is jump height
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("DeathZone"))
        {
            transform.position = spawnPoint;
            velocity = Vector3.zero;
        }
    }
}
