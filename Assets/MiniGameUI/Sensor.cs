using UnityEngine;

public class Sensor : MonoBehaviour
{
    public TargetSpawner gameManager;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Object")
        {
            gameManager.GameOver();
            gameManager.RestartGameButtonAppears();
            gameManager.spawningStatus = false;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BadObject")
        {
            Destroy(other.gameObject);
        }
    }
}
