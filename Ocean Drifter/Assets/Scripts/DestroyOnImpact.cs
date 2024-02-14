using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    BoatSink boatSink;

    // Start is called before the first frame update
    void Start()
    {
        boatSink = GameObject.Find("Player").GetComponent<BoatSink>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ocean"))
        {
            Destroy(gameObject, 0.5f);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            boatSink.SinkBoat();
            Destroy(other.gameObject, 2f);
        }
    }
}
