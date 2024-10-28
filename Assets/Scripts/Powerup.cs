using UnityEngine;

public class Powerup : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            Destroy(this.gameObject);
        }
    }
}
