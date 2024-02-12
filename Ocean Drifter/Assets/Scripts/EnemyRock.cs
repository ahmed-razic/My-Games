using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRock : MonoBehaviour
{
    [SerializeField] float randomForce;
    [SerializeField] float randomTorque;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        randomForce = Random.Range(130f, 175f);
        randomTorque = Random.Range(10f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(randomForce * transform.forward, ForceMode.Impulse);
        body.AddTorque(randomTorque * transform.right, ForceMode.Impulse);
    }
}
