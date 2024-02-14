using UnityEngine;

public class BoatSway : MonoBehaviour
{
    float timer = 0;
    int maxAngle;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (gameManager.waves == GameManager.Waves.Calm)
        {
            maxAngle = 5;
            timer += Time.deltaTime;
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.Find("Player").transform.forward);
        }

        else if (gameManager.waves == GameManager.Waves.Rough)
        {
            maxAngle = 10;
            timer += Time.deltaTime;
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.Find("Player").transform.right);
        }
    }    /*
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
    */
}
