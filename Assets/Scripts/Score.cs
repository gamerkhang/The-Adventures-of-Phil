using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Application.loadedLevelName == "FrogStomach")
            ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.gameOver)
            SaveScore();
	}
    void ResetScore() { PlayerPrefs.SetInt("PointsValue", 0); }

    void SaveScore() 
    { 
        PlayerPrefs.SetInt("PointsValue", ApplicationModel.score);
        if (ApplicationModel.score > GetHiScore())
            PlayerPrefs.SetInt("HiScore", ApplicationModel.score);
    }

    public int GetScore() { return PlayerPrefs.GetInt("PointsValue"); }

    public int GetHiScore() { return PlayerPrefs.GetInt("HiScore"); }
}