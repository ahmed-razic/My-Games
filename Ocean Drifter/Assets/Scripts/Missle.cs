using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    GameManager gameManager;

    float forwardSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += forwardSpeed * Time.deltaTime * transform.forward;
        if(transform.position.z > 600)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
            gameManager.AddScore(10);
        }
    }
}
