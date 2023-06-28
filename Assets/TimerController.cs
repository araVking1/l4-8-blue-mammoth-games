using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float level1Duration = 15f;
    public float level2Duration = 15f;
    public string level2SceneName = "Level2Scene";
    public string level1SceneName = "Level1Scene";

    private float currentTime;
    private TextMeshProUGUI timerText;
    private bool level2Triggered;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        ResetTimer();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            if (SceneManager.GetActiveScene().name == level1SceneName && !level2Triggered)
            {
                level2Triggered = true;
                SceneManager.LoadScene(level2SceneName);
            }
            else if (SceneManager.GetActiveScene().name == level2SceneName)
            {
                SceneManager.LoadScene(level1SceneName);
            }
        }

        timerText.text = currentTime.ToString("F0");
    }

    public void ResetTimer()
    {
        currentTime = SceneManager.GetActiveScene().name == level1SceneName ? level1Duration : level2Duration;
        timerText.text = currentTime.ToString("F0");
    }
}
