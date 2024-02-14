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
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(5);
        if (gameManager.lives < 1)
        {
            Destroy(player);

        } else
        {
            player.transform.position = player.GetComponent<PlayerController>().startingPosition; 
        }
        StopCoroutine(nameof(RespawnPlayer));
    }
}
