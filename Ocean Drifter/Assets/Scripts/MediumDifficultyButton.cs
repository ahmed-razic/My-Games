using UnityEngine;
using UnityEngine.UI;

public class MediumDifficultyButton : MonoBehaviour
{
    GameManager gameManager;
    Button button;
    public int mediumDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetMediumDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetMediumDifficulty()
    {
        gameManager.StartGame(mediumDifficulty);
    }
}