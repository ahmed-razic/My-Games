using System.Collections;
using UnityEngine;

public class BoatSink : MonoBehaviour
{
    public float sinkingSpeed = 10f;
    public bool isBoatHit = false;
    GameObject player;
    GameManager gameManager;


    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (isBoatHit)
        {
            SinkBoat();
        }
    }
    public void SinkBoat()
    {
        transform.Translate(sinkingSpeed * Time.deltaTime * Vector3.down);
        if (gameManager.lives == 0)
        {
            Destroy(player, 4);
            gameManager.isGameRunning = false;
        }
        else
        {
            StartCoroutine(RepositionPlayer());
        }
    }

    IEnumerator RepositionPlayer()
    {
        yield return new WaitForSeconds(4);
        isBoatHit = false;
        player.transform.position = player.GetComponent<PlayerController>().startingPosition;
    }
}
