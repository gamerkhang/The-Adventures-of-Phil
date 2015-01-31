using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour 
{
	void Awake () 
    {
        if(PlayerPrefs.GetInt("HighScore") < SavedValues.score)
            PlayerPrefs.SetInt("HighScore", SavedValues.score);
	}
}
