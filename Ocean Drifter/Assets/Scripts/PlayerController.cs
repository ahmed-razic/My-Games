using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isDead;
    public bool isSeaCalm;
    public float forwardSpeed = 10.0f;
    private BoatSwaying boatSwaying;

    // Start is called before the first frame update
    void Start()
    {
        boatSwaying = GetComponent<BoatSwaying>();
        StartCoroutine(boatSwaying.BoatSway(true));

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(forwardSpeed * Input.GetAxis("Vertical") * Time.deltaTime * Vector3.forward);
        while (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            StopCoroutine(boatSwaying.BoatSway(true));            
        }
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
    }
}
