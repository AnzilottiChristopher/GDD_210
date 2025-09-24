using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startTime = 60f;
    public float currentTime;
    public TextMeshProUGUI timerText;
    public GameObject loseScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loseScreen.SetActive(false);
        currentTime = startTime;
        timerText.text = "Time: " + currentTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0);

        timerText.text = "Time: " + Mathf.CeilToInt(currentTime);

        if (currentTime <= 0)
        {
            //End Game
            loseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
