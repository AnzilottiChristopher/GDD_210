using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winScreen;

    void Awake()
    {
        scoreManager = this;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    void Start()
    {
        winScreen.SetActive(false);
    }
    void Update()
    {
        if (score >= 11)
        {
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;


            Timer gm = GameObject.Find("GameManager").GetComponent<Timer>();
            if(gm != null)
            {
                gm.currentTime = 20;
            }
        }
    }
}
