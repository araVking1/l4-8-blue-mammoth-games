using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public string sceneToLoad = "Scene"; // Assign the scene name here

    void Update()
    {
        score = (int)Time.time;
        scoreText.text = score.ToString();

        if (score >= 5)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
