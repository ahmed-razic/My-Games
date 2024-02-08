using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSink : MonoBehaviour
{
    public float sinkingSpeed = 1f;

    public void SinkBoat()
    {
        transform.Translate(sinkingSpeed * Time.deltaTime * Vector3.down);
    }
}
