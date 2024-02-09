using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public float forwardSpeed = 30.0f;
    public float rotateSpeed = 100.0f;
    private float horizontalInput;
    private float verticalInput;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameObject.Find("Boat Parent").GetComponent<BoatSwaying>().Calm());
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.position += verticalInput * forwardSpeed * Time.deltaTime * transform.forward; // This is much better
        transform.Rotate(horizontalInput * rotateSpeed * Time.deltaTime * Vector3.up);
    }
}
