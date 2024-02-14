using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    BoatSink boatSink;
    GameManager gameManager;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        boatSink = GameObject.Find("Player").GetComponent<BoatSink>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

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
            boatSink.isBoatHit = true;
            gameManager.lives -= 1;
            if (gameManager.lives >= 1)
            {
                Debug.Log("IN COROUTINE");
                StartCoroutine(RespawnPlayer());
            }
            else if (gameManager.lives == 0)
            {
                Destroy(other.gameObject);
                gameManager.isGameRunning = false;
            }            
        }

    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(3);
        boatSink.isBoatHit = false;
        player.transform.position = player.GetComponent<PlayerController>().startingPosition;
        Debug.Log("IN RESPAWN");
        //StopCoroutine(nameof(RespawnPlayer));
    }
}
