using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveSmoothness = 10f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 200f;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 smoothMove;
    private float xRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        moveInput = (transform.right * x + transform.forward * z).normalized;
    }

    void FixedUpdate()
    {
        smoothMove = Vector3.Lerp(smoothMove, moveInput, moveSmoothness * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + smoothMove * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
