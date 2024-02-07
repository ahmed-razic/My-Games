using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSwaying : MonoBehaviour
{
    public float swayRotationSpeed;
    public float rotationZ;
    public float rotationZ1;
    public float maxSwayAngle;

    // Start is called before the first frame update
    void Start()
    {
        swayRotationSpeed = 2f;
        maxSwayAngle = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward, swayRotationSpeed * Time.deltaTime);
        rotationZ = transform.rotation.eulerAngles.z;

        if (transform.rotation.eulerAngles.z > 5)
        {
            swayRotationSpeed = -Random.Range(2f, 5f);
            //maxSwayAngle = Random.Range(2f, 5f);
            Debug.Log("fdssdfsd");
        }
        else if (transform.rotation.eulerAngles.z < 360)
        {
            swayRotationSpeed = Random.Range(2f, 5f);
            //maxSwayAngle = Random.Range(2f, 5f);
        }

    }
}
