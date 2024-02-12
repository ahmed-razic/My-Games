
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyRocksPrefabs;
    public List<GameObject> enemyShipsPrefabs;

    float spawnDelay = 2f;
    float spawnInterval = 3f;
    int numberOfEnemyRocks = 0;
    int numberOfEnemyShips = 0;

    GameObject player;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating(nameof(SpawnEnemyRocks), spawnDelay, spawnInterval);
        InvokeRepeating(nameof(SpawnEnemyShips), spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemyRocks()
    {
        int randomIndex = Random.Range(0, enemyRocksPrefabs.Count);
        Vector3 randomPosition = new(Random.Range(-200f, 200f), Random.Range(200f, 300f), player.transform.position.z + 400f);
        if (gameManager.isGameRunning && numberOfEnemyRocks < 10)
        {
            Instantiate(enemyRocksPrefabs[randomIndex], randomPosition, enemyRocksPrefabs[randomIndex].transform.rotation);
            numberOfEnemyShips++;
        }
    }

    void SpawnEnemyShips()
    {

        int randomIndex = Random.Range(0, enemyShipsPrefabs.Count);
        Vector3 randomPosition = new(Random.Range(-200f, 200f), 0, player.transform.position.z + 400f);
        if (gameManager.isGameRunning && numberOfEnemyShips < 10)
        {
            Instantiate(enemyShipsPrefabs[randomIndex], randomPosition, enemyShipsPrefabs[randomIndex].transform.rotation);
            numberOfEnemyRocks++;
        }
    }
}
