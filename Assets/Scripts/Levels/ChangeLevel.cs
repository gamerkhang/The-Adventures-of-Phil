using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("Phil"))
            GameObject.Find("Phil").GetComponent<Movement>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Level (string levelName)
	{
		Application.LoadLevel (levelName);
	}

    public void MainMenu()
    {
        SavedValues.score = 0;
        SavedValues.time = 0;
        Application.LoadLevel(0);
    }

    public void RestartLevel()
    {
        SavedValues.score = 0;
        SavedValues.time = 0;
        Application.LoadLevel(Application.loadedLevelName);
    }

	public void Quit ()
	{
		Application.Quit();
	}
}
