using UnityEngine;
using UnityEngine.InputSystem;

public class Forcefield : MonoBehaviour
{
    public float radius = 5f; // Radius of the affected area
    public Color gizmoColor = Color.white; // Default Gizmo color
    private Color currentGizmoColor;
    public float gravityMultiplier;

    private PlayerController playerInArea;

    // Start is called before the first frame update
    void Start()
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = radius; // Assign radius to SphereCollider

        currentGizmoColor = gizmoColor; // Initialize the Gizmo color
    }

    // This is where you draw the Gizmos
    void OnDrawGizmos()
    {
        Gizmos.color = currentGizmoColor; // Use the current color for Gizmos
        Gizmos.DrawWireSphere(transform.position, radius); // Draw a wireframe sphere
    }

    // Detect when an object enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentGizmoColor = Color.green; // Change Gizmo color when Player enters
            Debug.Log(other.gameObject.name + " has entered the field");
            Debug.Log("Player is now being slowed");
            playerInArea = other.GetComponent<PlayerController>();
            //playerInArea.gravityModifier *= gravityMultiplier;
        }
        else
        {
            currentGizmoColor = Color.blue; // Change Gizmo color when non-player enters
            Debug.Log(other.gameObject.name + "entered the area");
        }
    }

    // Detect when an object leaves the trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has left the area");
            currentGizmoColor = Color.red; // Change Gizmo color when Player leaves
            //playerInArea.gravityModifier = 1;
        }
        else
        {
            Debug.Log("Object has left the area");
            currentGizmoColor = gizmoColor; // Revert to default color when non-player leaves
        }
    }
}
