using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;
    public Levels level = Levels.Level1;
    public Waves waves;
    OceanWaves oceanWavesScript;

    public enum Waves
    {
        Calm,
        Rough
    }

    public enum Levels
    {
        Level1, 
        Level2
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
        waves = Waves.Calm;
        oceanWavesScript = GameObject.Find("Ocean").GetComponent<OceanWaves>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set ocean waves
        if (waves == Waves.Calm)
        {
            oceanWavesScript.SetOceanWaves(1f, 1f, 0.5f, new Vector3(0f, -20f, 0f));
        }
        else if (waves == Waves.Rough)
        {
            oceanWavesScript.SetOceanWaves(3f, 2f, 0.5f, new Vector3(0f, -20f, 0f));
        }

        //set respawn logic based on level

        if (level == Levels.Level1)
        {
            for (int i = 0; i < 3; i++)
            {

            }
            level = Levels.Level2;
        }

        if(level == Levels.Level2)
        {
            for (int i = 0; i < 3; i++)
            {

            }
        }
    }
}
