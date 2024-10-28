using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    public float secondsTillSpawn;
    private Button button;
    private TargetSpawner gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Target Spawner").GetComponent<TargetSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManager.GameStart(secondsTillSpawn);

    }
}
