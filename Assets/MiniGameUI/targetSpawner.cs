using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] gameObjects; // List of spawnable objects
    private int objectCounter;
    public float spawnRangeXMin;
    public float spawnRangeXMax;
    public float spawnRangeYMin;
    public float spawnRangeYMax;
    public float spawnRangeZMin;
    public float spawnRangeZMax;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI mainMenu;
    public Button restartButton;
    public Button easyButton;
    public Button mediumBotton;
    public Button hardButton;
    private int score;
    private float secondsToWait;
    public bool spawningStatus;

    void Start()
    {
        spawningStatus = true;
        score = 0;
        UpdateScore(0);
        GameOptions();
    }

    void Update()
    {

    }


    public void GameStart(float secondsToWait)
    {
        StartCoroutine(SpawningProcedure(secondsToWait));
        easyButton.gameObject.SetActive(false);
        mediumBotton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);

    }
    public IEnumerator SpawningProcedure(float waitForSeconds)
    {
        while (spawningStatus)  // Infinite loop to spawn every 5 seconds
        {
            StartTheSpawn();
            yield return new WaitForSeconds(waitForSeconds);  // Wait 5 seconds before next spawn
        }
    }

    public void StartTheSpawn()
    {
        // Select a random GameObject from the array
        int randomIndex = Random.Range(0, gameObjects.Length);
        GameObject selectedObject = gameObjects[randomIndex];

        // Generate a random position within the defined ranges
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnRangeXMin, spawnRangeXMax),
            Random.Range(spawnRangeYMin, spawnRangeYMax),
            Random.Range(spawnRangeZMin, spawnRangeZMax)
        );

        // Spawn the selected object at the random position
        Instantiate(selectedObject, randomPosition, Quaternion.identity);
    }

    public void UpdateScore(int addToScore)
    {
        score += addToScore;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGameButtonAppears()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOptions()
    {
        //Sets the gameobjects to be active at the beginning of the game
        easyButton.gameObject.SetActive(true);
        mediumBotton.gameObject.SetActive(true);
        hardButton.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }
}
