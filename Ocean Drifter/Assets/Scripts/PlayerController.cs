using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isDead;
    public bool isSeaCalm;
    public float forwardSpeed = 30f;
    public float rotateSpeed = 100.0f;
    private float horizontalInput;
    private float verticalInput;
    private BoatSwaying bw;
    

    // Start is called before the first frame update
    void Start()
    {
        bw = GetComponent<BoatSwaying>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(verticalInput * forwardSpeed * Time.deltaTime * transform.forward);  - This moves object translatory, looks aqward
       
        
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            StartCoroutine(bw.BoatSway(true));
        }
        else
        {
            StopCoroutine(bw.BoatSway(true));
            transform.position += verticalInput * forwardSpeed * Time.deltaTime * transform.forward; // This is much better
            transform.Rotate(horizontalInput * rotateSpeed * Time.deltaTime * Vector3.up);
        }

        //playerRb.AddRelativeForce(force * Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime, ForceMode.VelocityChange);
        //playerRb.AddTorque(force * Input.GetAxis("Horizontal") * Time.deltaTime * Vector3.up);
    }
}
