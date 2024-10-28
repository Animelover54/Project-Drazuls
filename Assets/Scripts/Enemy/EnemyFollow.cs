using System.Numerics;
using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRb;
    private GameObject player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
