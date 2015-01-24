using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static bool gameRunning;
	public static bool gameOver;
	public static string minutes, seconds;
	public static int lives;
	public static float currentTime, prevTime, startTime;
	GameObject pauseMenu, gameOverMenu;

	// Use this for initialization
	void Start () {
		lives = 1;
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
		gameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");
		pauseMenu.SetActive(false);
		gameOverMenu.SetActive(false);
        gameRunning = true;
        gameOver = false;
        ApplicationModel.score = 0;
		startTime = Time.time;
		currentTime = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            prevTime = currentTime;
            currentTime = Time.time;
        }
		ApplicationModel.score += (int)((currentTime - prevTime) * 100);
		if (Input.GetButtonDown("Pause"))
			Pause();
		else if (lives == 0 && gameOver == false)
			GameOver();
	}

	public void Pause() {
		Time.timeScale = 0;
		gameRunning = false;
		pauseMenu.SetActive(true);
	}

	public void Unpause () {
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
		gameRunning = true;
	}

	public void GameOver() {
		gameOver = true;
		float timer = currentTime - startTime;
		minutes = Mathf.Floor(timer / 60).ToString("00");
		seconds = Mathf.Floor(timer % 60).ToString("00");
		gameOverMenu.SetActive(true);
	}
}
