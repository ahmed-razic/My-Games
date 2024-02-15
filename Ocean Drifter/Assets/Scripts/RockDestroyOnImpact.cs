using UnityEngine;

public class RockDestroyOnImpact : MonoBehaviour
{
    SinkBoat sinkBoat;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        sinkBoat = GameObject.Find("Player").GetComponent<SinkBoat>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ocean"))
        {
            Destroy(gameObject, 1f);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.LooseLife();
            sinkBoat.isBoatHit = true;
            if(gameManager.lives == 0)
            {
                gameManager.EndGame();
            }
        }
    }
}
