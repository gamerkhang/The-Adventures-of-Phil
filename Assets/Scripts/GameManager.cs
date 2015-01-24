using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public bool gameRunning = true;
	GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
		pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause"))
		{
			Time.timeScale = 0;
			gameRunning = false;
			pauseMenu.SetActive(true);
		}
	}

	public void Unpause () {
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
		gameRunning = true;
	}
}
