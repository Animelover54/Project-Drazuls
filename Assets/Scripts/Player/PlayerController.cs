using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    public float jump = 10f;  // Jump force
    public bool isOnGround;
    public float movementSpeed = 5f;  // Default speed, can be modified in the Inspector
    public GameObject skill;
    public Transform skillTransform;

    // Camera and Mouse Controls
    public Transform cameraTransform;  // Reference to the camera's transform
    public float mouseSensitivity = 2f;  // Mouse sensitivity for camera movement
    private float cameraPitch = 0f;  // Vertical camera rotation tracking

    // Animations
    [SerializeField] private Animator animator;
    [SerializeField] private float horizontalAnim = 0f;
    [SerializeField] private float verticalAnim = 0f;

    //Effects
    public bool poweredUp = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor in the game
    }

    void Update()
    {
        RotateCamera();  // Rotate the camera based on mouse movement
        Movement();      // Move the player based on camera direction
        Skills();        // Handle player skills
        CheckingDeath(); // Check if the player is dead
    }

    // Rotate the camera based on mouse movement
    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player based on the horizontal mouse movement (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Clamp the vertical camera rotation (pitch) and rotate
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
        cameraTransform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
    }

    // Movement dependent on camera direction
    void Movement()
    {
        // Get camera's forward and right direction, but ignore the y-axis (flatten it)
        Vector3 forward = new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z).normalized;
        Vector3 right = new Vector3(cameraTransform.right.x, 0f, cameraTransform.right.z).normalized;

        // Player movement input
        float moveDirectionX = 0f;  // X direction movement
        float moveDirectionZ = 0f;  // Z direction movement

        // Forward / backward movement
        if (Input.GetKey(KeyCode.W))
        {
            moveDirectionZ = 1f;  // Move forward
            verticalAnim = 0.5f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirectionZ = -1f;  // Move backward
            verticalAnim = -0.5f;
        }
        else
        {
            verticalAnim = 0f;
        }

        // Left / right movement
        if (Input.GetKey(KeyCode.A))
        {
            moveDirectionX = -1f;  // Move left
            horizontalAnim = -0.5f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirectionX = 1f;  // Move right
            horizontalAnim = 0.5f;
        }
        else
        {
            horizontalAnim = 0f;
        }

        // Apply animation values
        animator.SetFloat("horizontal", horizontalAnim);
        animator.SetFloat("vertical", verticalAnim);

        // Calculate the final movement direction based on camera's orientation
        Vector3 moveDirection = (forward * moveDirectionZ + right * moveDirectionX).normalized;

        // Apply the movement to the player
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;  // Temporarily set to false to avoid double jumping
            animator.SetTrigger("isTrigger");
        }
    }

    void Skills()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetTrigger("punch");
            Instantiate(skill, skillTransform);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("slideAttack");
        }
    }

    void CheckingDeath()
    {
        if (Input.GetKey(KeyCode.L))
        {
            animator.SetBool("isDead", true);
            GameObject.Destroy(this.GetComponent<PlayerController>());
            Debug.Log("Player is dead");
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(5);
        transform.localScale = new Vector3(1, 1, 1);
        poweredUp = false;
    }


    // Ground check when landing
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (other.gameObject.tag == "Powerup")
        {
            Transform transform = GetComponent<Transform>();

            StartCoroutine(PowerupCountdown());

            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup")
        {
            transform.localScale = new Vector3(2, 2, 2);

            poweredUp = true;
        }
    }
}

