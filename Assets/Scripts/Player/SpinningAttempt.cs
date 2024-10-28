using UnityEngine;

public class SpinningAttempt : MonoBehaviour
{
    public float spinningSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinningSpeed * Time.deltaTime, 0, Space.World);
    }
}
