using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    private int randomNumber;
    public GameObject commonObject;
    public GameObject uncommonObject;
    public GameObject rareObject;
    public GameObject epicObject;
    public GameObject legendaryObject;
    public GameObject mythicObject;
    public GameObject transcendentObject;
    private GameObject randomObject;
    private Transform objectSpawn;
    public Transform commonSpawn;
    public Transform uncommonSpawn;
    public Transform rareSpawn;
    public Transform epicSpawn;
    public Transform legendarySpawn;
    public Transform mythicSpawn;
    public Transform transcendantSpawn;



    void Update()
    {
        SpawnFunction();
    }

    public void SpawnFunction()
    {
        // Check for input
        if (Input.GetKey(KeyCode.P))
        {
            // Generate a random number between 1 and 1,020,000
            int randomNumber = Random.Range(1, 1020001);

            // Assign the object based on the rarity
            if (randomNumber <= 830000)  // 83% chance for Common
            {
                randomObject = commonObject;
                objectSpawn = commonSpawn;

            }
            else if (randomNumber <= 970000)  // 14% chance for Uncommon
            {
                randomObject = uncommonObject;
                objectSpawn = uncommonSpawn;
            }
            else if (randomNumber <= 995000)  // 2.5% chance for Rare
            {
                randomObject = rareObject;
                objectSpawn = rareSpawn;
            }
            else if (randomNumber <= 1005500)  // 1.05% chance for Epic
            {
                randomObject = epicObject;
                objectSpawn = epicSpawn;
            }
            else if (randomNumber <= 1013000)  // 0.75% chance for Legendary
            {
                randomObject = legendaryObject;
                objectSpawn = legendarySpawn;
            }
            else if (randomNumber <= 1018000)  // 0.5% chance for Mythic
            {
                randomObject = mythicObject;
                objectSpawn = mythicSpawn;
            }
            else  // 0.2% chance for Transcendent
            {
                randomObject = transcendentObject;
                objectSpawn = transcendantSpawn;
            }

            // Instantiate the selected object
            Instantiate(randomObject, objectSpawn.position, objectSpawn.rotation);
        }
    }
}
