using System.Collections;
using UnityEngine;

public class SinkBoat : MonoBehaviour
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
            SinkAnyBoat();
        }
    }
    public void SinkAnyBoat()
    {
        transform.Translate(sinkingSpeed * Time.deltaTime * Vector3.down);
        if (gameObject.CompareTag("Ship"))
        {
            Destroy(gameObject, 3);
        }

        if (gameManager.lives == 0)
        {
            Destroy(player, 4);
            gameManager.EndGame();
        }

        else
        {
            StartCoroutine(RepositionPlayer());
        }
    }

    IEnumerator RepositionPlayer()
    {
        yield return new WaitForSeconds(4);
        if (gameObject.CompareTag("Player"))
        {
            isBoatHit = false;
            player.transform.position = player.GetComponent<PlayerController>().startingPosition;
        }
    }
}
