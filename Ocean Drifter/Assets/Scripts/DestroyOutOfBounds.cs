using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -450f)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z > 500)
        {
            Destroy(gameObject);
        }
    }
}
