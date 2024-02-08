using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isDead;
    public bool isSeaCalm;
    public float force = 1.0f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.AddRelativeForce(force * Input.GetAxis("Vertical") * Vector3.forward);
        playerRb.AddTorque(force * Input.GetAxis("Horizontal") * Vector3.up);


    }
}
