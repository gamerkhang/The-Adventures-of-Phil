using UnityEngine;
using System.Collections;

public class GameManagerNoPlayer : MonoBehaviour {

    GameObject pauseMenu;

	// Use this for initialization
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        pauseMenu.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Pause"))
            Pause();
	}

    public void Pause()
    {
        //GameObject.Find("IntroText").GetComponent<CanvasRenderer>().Clear();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        //if (Application.loadedLevelName == "IntroText")
        //    GameObject.Find("IntroText").GetComponent<CanvasRenderer>().active = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
