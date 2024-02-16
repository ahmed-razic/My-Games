using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRock : MonoBehaviour
{
    [SerializeField] float randomForce;
    [SerializeField] float rotateSpeed;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        randomForce = Random.Range(30f, 60f);
        rotateSpeed = 10f;        
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(randomForce * transform.forward, ForceMode.Impulse);
        transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
        if(transform.position.y < -300)
        {
            Destroy(gameObject);
        }
    }
}
