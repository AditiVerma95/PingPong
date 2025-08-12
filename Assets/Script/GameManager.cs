using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int blueScore = 0;
    public int redScore = 0;
    public Text blueScoreText;
    public Text redScoreText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScoreToBlue()
    {
        blueScore++;
        blueScoreText.text = blueScore.ToString();
        // Play score sound/animation if desired
    }

    public void AddScoreToRed()
    {
        redScore++;
        redScoreText.text = redScore.ToString();
    }
}