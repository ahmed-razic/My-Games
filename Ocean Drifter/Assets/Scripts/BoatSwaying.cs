using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSwaying : MonoBehaviour
{
    private float swayRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward, swayRotationSpeed * Time.deltaTime);
        if (transform.rotation.z < 1)
        {
            swayRotationSpeed *= -1;
        }

    }
}
