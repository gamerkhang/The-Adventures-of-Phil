using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Level (string levelName)
	{
		Application.LoadLevel (levelName);
	}

	public void Quit ()
	{
		Application.Quit();
	}
}
