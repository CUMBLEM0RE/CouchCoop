using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;

    Transform playerContainer, cameraContainer;
    
    private Vector3 p_position;

    public float speed = 6.0f;
    public float jumpSpeed = 10.0f;
    public float mouseSensitivity = 2f;
    public float gravity = 20.0f;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 60f;
    public float originalHeight;
    public float reducedHeight;
    public float speedBoost = 10f;

    private Vector3 moveDirection = Vector3.zero;
    float rotateX, rotateY;

    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        //playerContainer = gameObject.transform.Find("Container3P");
        //cameraContainer = playerContainer.transform.Find("Camera3PContainer");
        characterController = GetComponent<CharacterController>();
        originalHeight = characterController.height;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Locomotion();
        //RotateAndLook();
    }

    void Locomotion()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void RotateAndLook()
    {
        rotateX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDownClamp);

        transform.Rotate(0f, rotateX, 0f);

        cameraContainer.transform.localRotation = Quaternion.Euler(rotateY, 0f, 0f);
    }
}
