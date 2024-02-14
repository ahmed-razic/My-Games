using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    BoatSink boatSink;
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        boatSink = GameObject.Find("Player").GetComponent<BoatSink>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        

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
            gameManager.lives -= 1;
            boatSink.isBoatHit = true;    
        }
    }    
}
