using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static bool gameRunning;
    public static bool gameOver;
    public static bool gameOverScreen;
	public static string minutes, seconds;
	public static int lives;
	public static float currentTime, prevTime, startTime;
    public static bool beenHit = false;

	GameObject pauseMenu, gameOverMenu;

    public float invincibleTime = 1f;

    int prevLives;
    GameObject player;
    GameObject playerCollider;
    GameObject playerSprite;

    void Awake()
    {
        if (Application.loadedLevelName == "Intro")
            SaveValue.time = 0f;
    }

	// Use this for initialization
	void Start () {
		lives = 6;
        prevLives = lives;
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
		gameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");
		pauseMenu.SetActive(false);
		gameOverMenu.SetActive(false);
        gameRunning = true;
        gameOver = false;
        gameOverScreen = false;
        //Score.score = 0;
		startTime = Time.time;
        currentTime = startTime;

		player = GameObject.FindWithTag("Player");
		player.GetComponent<Movement>().enabled = true;
		player.rigidbody2D.gravityScale = 0;

        foreach (Transform t in player.transform)
        {
            if (t.name == "Colliders")
                playerCollider = t.gameObject;
            else if (t.name == "PhilSprite")
                playerSprite = t.gameObject;
        }

        StartCoroutine("IncreaseScore");
	}

	
	// Update is called once per frame
	void Update () {
        if (beenHit)
        {
            GameManager.lives -= 1;
            beenHit = false;
        }
        if (prevLives > lives && lives > 0)
            StartCoroutine("Invincibility");

        if (!gameOver)
        {
            prevTime = currentTime;
            currentTime = Time.time;
        }

		if (Input.GetButtonDown("Pause"))
			Pause();
        else if (lives <= 0 && gameOverScreen == false)
        {
			player.GetComponent<Movement>().enabled = false;
			player.rigidbody2D.gravityScale = 1;
            GameOver();
        }

        prevLives = lives;
	}

    void OnDestroy()
    {
        if (!gameOverScreen)
            UpdatePlayTime();
    }

    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(Spawn.timeTilStart);
        while(!gameOver)
        {
            SaveValue.score += 50;
            yield return new WaitForSeconds(0.5f);
        }
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
		gameOverScreen = true;
        UpdatePlayTime();
        SaveValue.time = 0f;
		gameOverMenu.SetActive(true);
	}

    void UpdatePlayTime()
    {
        float timer;
        timer = SaveValue.time;
        timer += currentTime - startTime;
        SaveValue.time = timer;
        minutes = Mathf.Floor(timer / 60).ToString("00");
        seconds = Mathf.Floor(timer % 60).ToString("00");
    }

    IEnumerator Invincibility()
    {
        if(player != null)
            playerCollider.SetActive(false);
        for (float i = 0; i <= invincibleTime && player != null; i += invincibleTime/5f)
        {
            playerSprite.SetActive(!playerSprite.activeSelf);
            yield return new WaitForSeconds(invincibleTime / 5f);
        }
        if(player != null)
            playerCollider.SetActive(true);
    }
}
