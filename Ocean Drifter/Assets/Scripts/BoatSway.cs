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
        if (gameManager.waves == GameManager.Waves.Calm && gameManager.isGameRunning)
        {
            maxAngle = 5;
            timer += Time.deltaTime;
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.Find("Player").transform.forward);
        }

        else if (gameManager.waves == GameManager.Waves.Rough && gameManager.isGameRunning)
        {
            maxAngle = 10;
            timer += Time.deltaTime;
            float angle = Mathf.Sin(timer) * maxAngle;
            transform.rotation = Quaternion.AngleAxis(angle, transform.Find("Player").transform.right);
        }
    }
}
