using UnityEngine;

public class ThirdPersonCameraOption : MonoBehaviour
{
    public GameObject ThirdPersonCamera;  // The third-person camera
    public GameObject FirstPersonCamera;  // The default/first-person camera
    private bool isThirdPerson = false;   // Keeps track of the current camera mode

    [SerializeField] private Transform centerOfMass; // Focal point for camera orbit

    public float rotationSpeed = 5f; // Speed of camera rotation
    public float distanceFromTarget = 5f; // Distance the camera should be from the target

    private float verticalRotation = 0f; // Vertical rotation (up/down)
    private float horizontalRotation = 0f; // Horizontal rotation (left/right)

    void Start()
    {
        // Ensure the first-person camera is active and the third-person camera is not at the start
        FirstPersonCamera.SetActive(true);
        ThirdPersonCamera.SetActive(false);
    }

    void Update()
    {
        ActivatingThirdPersonCamera();

        if (isThirdPerson)
        {
            PlayerInput();
        }
    }

    void ActivatingThirdPersonCamera()
    {
        // Check if the 'T' key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Toggle between first-person and third-person views
            isThirdPerson = !isThirdPerson;

            if (isThirdPerson)
            {
                // Switch to third-person view
                FirstPersonCamera.SetActive(false);
                ThirdPersonCamera.SetActive(true);
            }
            else
            {
                // Switch to first-person view
                ThirdPersonCamera.SetActive(false);
                FirstPersonCamera.SetActive(true);
            }
        }
    }

    void PlayerInput()
    {
        // Check if the right mouse button is held down
        if (Input.GetKey(KeyCode.Mouse1))
        {
            // Get the mouse movement inputs
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            // Rotate the camera horizontally (left/right)
            horizontalRotation += mouseX;

            // Rotate the camera vertically (up/down)
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f); // Clamp vertical rotation to avoid flipping

            // Calculate the new position of the camera based on horizontal/vertical rotation
            Vector3 direction = new Vector3(0, 0, -distanceFromTarget); // Start with a vector behind the target
            Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f); // Calculate rotation
            ThirdPersonCamera.transform.position = centerOfMass.position + rotation * direction; // Update camera position

            // Make the camera look at the centerOfMass object
            ThirdPersonCamera.transform.LookAt(centerOfMass);
        }
    }
}
