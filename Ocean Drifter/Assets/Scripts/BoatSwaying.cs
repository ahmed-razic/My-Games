using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSwaying : MonoBehaviour
{
    public IEnumerator BoatSway(bool isSeaCalm)
    {
        float timer = 0;
        int maxAngle = 7;

        while (isSeaCalm)
        {
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            timer += Time.deltaTime;
            yield return null;
        }
        
        while (!isSeaCalm)
        {
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);

            timer += Time.deltaTime;
            yield return null;
        }
    }  
}
