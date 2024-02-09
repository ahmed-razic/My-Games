using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSwaying : MonoBehaviour
{
    public IEnumerator Calm()
    {
        float timer = 0;
        int maxAngle = 5;

        while (true)
        {
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

            timer += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator Hard()
    {
        float timer = 0;
        int maxAngle = 7;

        while (true)
        {
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.right);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
