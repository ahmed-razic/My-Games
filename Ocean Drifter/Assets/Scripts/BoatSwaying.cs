using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSwaying : MonoBehaviour
{

    private void Update()
    {
        StartCoroutine(BoatSway(true));
    }

    public IEnumerator BoatSway(bool isSeaCalm)
    {
        float timer = 0;
        int maxAngle = 7;

        while (isSeaCalm)
        {
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

            timer += Time.deltaTime;
            yield return null;
        }
        
        while (!isSeaCalm)
        {
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.right);

            timer += Time.deltaTime;
            yield return null;
        }
    }  
}
