using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float leftBorder = -200f;
    float rightBorder = 200f;
    float topBorder = -200f;
    float bottomBorder = -350f;
    public Vector3 startingPosition;

    public float forwardSpeed = 30.0f;
    public float rotateSpeed = 100.0f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.position += verticalInput * forwardSpeed * Time.deltaTime * transform.forward; // This is much better
        transform.Rotate(horizontalInput * rotateSpeed * Time.deltaTime * Vector3.up);

        //Limit movement of player
        if (transform.position.x < leftBorder)
        {
            transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBorder)
        {
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < bottomBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBorder);
        }
        else if (transform.position.z > topBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBorder);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // No longer necessary to Instantiate prefabs
            // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position + new Vector3(0, 1, 6); // position it at player
            }
        }
    }
}
