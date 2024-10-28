using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetSpawner targetSpawner;
    private Rigidbody targetRb;
    private Transform targetTransform;
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;

    public ParticleSystem explosionParticle;
    public int pointValue;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetTransform = GetComponent<Transform>();
        targetSpawner = GameObject.Find("Target Spawner").GetComponent<TargetSpawner>();

        // Add upward force with a random value between minSpeed and maxSpeed
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);

        // Add random torque
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque),
                           Random.Range(-maxTorque, maxTorque),
                           Random.Range(-maxTorque, maxTorque),
                           ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        Debug.Log("You got it");
        targetSpawner.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
