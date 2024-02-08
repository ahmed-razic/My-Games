using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSwaying : MonoBehaviour
{
    public float swayRotationSpeed;
    public float rotationZ;
    //public float rotationZ1;
    public float swayAngle;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        //swayRotationSpeed = 1f;
        //transform.Rotate(Vector3.forward, 2);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ObjectRotate());
        transform.Translate(transform.forward * 10 * Time.deltaTime * Input.GetAxis("Vertical"));
    }

    IEnumerator ObjectRotate()
    {
        float timer = 0;
        int maxAngle = 7;

        while (true)
        {
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
