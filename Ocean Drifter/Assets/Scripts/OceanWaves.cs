using UnityEngine;

public class OceanWaves : MonoBehaviour
{
    LowPolyWater.LowPolyWater ocean;

    // Start is called before the first frame update
    void Start()
    {
        ocean = GetComponent<LowPolyWater.LowPolyWater>();
    }

    public void SetOceanWaves(float waveHeight, float waveFrequency, float waveLength, Vector3 waveOrigin)
    {
        ocean.waveHeight = waveHeight;
        ocean.waveFrequency = waveFrequency;
        ocean.waveLength = waveLength;
        ocean.waveOriginPosition = waveOrigin;
    }
}
