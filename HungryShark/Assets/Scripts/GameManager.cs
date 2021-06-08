using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ObjectSpawner os;
    public SharkController sc;

    public int score = 0;
    public int health = 3;

    public Text scoreText;
    public Text healthText;

    public Text winText;
    public Text looseText;

    public GameObject playAgain;
    public Text playAgainText;

    public Timer tim;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartGame() {
        sc.inputEnabled = true;
        os.canSpawn = true;
        tim.timerIsRunning = true;
    }

    public void EndGame(bool win)
    {
        sc.inputEnabled = false;
        os.canSpawn = false;

        if (win)
        {
            winText.GetComponent<ScreenFader>().FadeOn();
        }
        else {
            looseText.GetComponent<ScreenFader>().FadeOn();
        }

        playAgain.GetComponent<ScreenFader>().FadeOn();
        playAgainText.GetComponent<ScreenFader>().FadeOn();
    }

    private void OnGUI()
    {
        scoreText.text = "SCORE: " + score.ToString();
        healthText.text = "HEALTH LEFT: " + health;
    }

    public void updateScore(int val) {
        score += val;

        scoreText.text = "SCORE: " + score.ToString();
    }

    public void updateHealth(int val) {
        health += val;

        healthText.text = "HEALTH LEFT: " + health;

        if (health <= 0) {
            sc.inputEnabled = false;
            sc.alive = false;
            os.canSpawn = false;
            tim.timerIsRunning = false;
            EndGame(false);
        }
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
}
