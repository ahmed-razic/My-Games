using UnityEngine;

public class ShipDestroyOnImpact : MonoBehaviour
{
    SinkBoat sinkBoat;
    SinkBoat sinkShip;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        sinkBoat = GameObject.Find("Player").GetComponent<SinkBoat>();
        sinkShip = GetComponent<SinkBoat>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.lives -= 1;
            sinkBoat.isBoatHit = true;
            sinkShip.isBoatHit = true;
            if (gameManager.lives == 0)
            {
                gameManager.EndGame();
            }
        }
    }
}
