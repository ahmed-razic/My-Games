
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyRocksPrefabs;
    public List<GameObject> enemyShipsPrefabs;

    [SerializeField] float spawnInterval;
    [SerializeField] int numberOfEnemyRocks = 0;
    int numberOfEnemyShips = 0;
    int enemyWave;

    GameObject player;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


        //InvokeRepeating(nameof(SpawnEnemyRocks), spawnDelay, spawnInterval);
        //InvokeRepeating(nameof(SpawnEnemyShips), spawnDelay, spawnInterval);
        StartGame(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnEnemyRocks(difficulty));
    }

    IEnumerator SpawnEnemyRocks(int difficulty)
    {
        spawnInterval /= difficulty;
        enemyWave = 1;

        Debug.Log("Wave 1");
        while (gameManager.isGameRunning && gameManager.level == GameManager.Levels.Level1)
        {
            yield return new WaitForSeconds(spawnInterval);

            int randomIndex = Random.Range(0, enemyRocksPrefabs.Count);
            Vector3 randomPosition = new(Random.Range(-200f, 200f), Random.Range(200f, 300f), player.transform.position.z + 400f);
            Instantiate(enemyRocksPrefabs[randomIndex], randomPosition, enemyRocksPrefabs[randomIndex].transform.rotation);
            numberOfEnemyRocks++;
            if (numberOfEnemyRocks == 10)
            {
                yield return new WaitForSeconds(5);
                Debug.Log("Wave 2");
                enemyWave = 2;
            }
            if (numberOfEnemyRocks == 20)
            {
                yield return new WaitForSeconds(5);
                Debug.Log("End of Level 1");
                gameManager.level = GameManager.Levels.Level2;
                StopCoroutine(nameof(SpawnEnemyRocks));
                StartCoroutine(SpawnEnemyShips(difficulty));
            }
        }
    }

    IEnumerator SpawnEnemyShips(int difficulty)
    {
        spawnInterval /= difficulty;
        enemyWave = 1;

        while (gameManager.isGameRunning && gameManager.level == GameManager.Levels.Level2)
        {
            yield return new WaitForSeconds(spawnInterval);
            int randomIndex = Random.Range(0, enemyShipsPrefabs.Count);
            Vector3 randomPosition = new(Random.Range(-200f, 200f), 0, player.transform.position.z + 400f);
            Instantiate(enemyShipsPrefabs[randomIndex], randomPosition, enemyShipsPrefabs[randomIndex].transform.rotation);
            numberOfEnemyShips++;

            if (numberOfEnemyShips == 10)
            {
                yield return new WaitForSeconds(5);
                Debug.Log("Wave 2");
                enemyWave = 2;
            }
            if (numberOfEnemyShips == 20)
            {
                yield return new WaitForSeconds(5);
                Debug.Log("End of Level 2");
                gameManager.level = GameManager.Levels.EndGame;
                StopCoroutine(nameof(SpawnEnemyShips));
                Debug.Log("End of Game");
            }
        }
    }
}
