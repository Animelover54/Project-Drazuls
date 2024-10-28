using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(1, 5);
        float spawnPositionZ = Random.Range(1, 5);

        Vector3 randomPos = new Vector3(spawnPositionX, 5, spawnPositionZ);

        return randomPos;
    }
}
