using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;
    public int score;
    public int lives;
    public Levels level;
    public Waves waves;
    OceanWaves oceanWavesScript;
    SpawnManager spawnManager;

    public Canvas startScreenCanvas;
    public Canvas endScreenCanvas;
    public Canvas inGameCanvas;

    public enum Waves
    {
        Calm,
        Rough
    }
    public enum Levels
    {
        Level1,
        Level2,
        EndGame
    }

    // Start is called before the first frame update
    void Start()
    {
        
        level = Levels.Level1;
        waves = Waves.Calm;
        oceanWavesScript = GameObject.Find("Ocean").GetComponent<OceanWaves>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Set ocean waves
        SetOceanWaves();
    }

    void SetOceanWaves()
    {
        if (waves == Waves.Calm)
        {
            oceanWavesScript.SetOceanWaves(1f, 1f, 0.5f, new Vector3(0f, -30f, 0f));
        }
        else if (waves == Waves.Rough)
        {
            oceanWavesScript.SetOceanWaves(3f, 2f, 0.5f, new Vector3(0f, -30f, 0f));
        }
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        lives = 3;
        isGameRunning = true;
        startScreenCanvas.enabled = false;
        inGameCanvas.enabled = true;
        spawnManager.StartCoroutine(spawnManager.SpawnEnemyRocks(difficulty));

    }

    public void EndGame()
    {
        isGameRunning = false;
        endScreenCanvas.enabled = true;
    }
}
