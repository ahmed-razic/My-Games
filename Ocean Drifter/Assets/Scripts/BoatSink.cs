using UnityEngine;

public class BoatSink : MonoBehaviour
{
    public float sinkingSpeed = 10f;
    public bool isBoatHit = false;

    private void Update()
    {
        if (isBoatHit)
        {
            SinkBoat();
        }
    }
    public void SinkBoat()
    {
        transform.Translate(sinkingSpeed * Time.deltaTime * Vector3.down);
    }
}
