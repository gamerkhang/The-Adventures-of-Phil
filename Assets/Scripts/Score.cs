//using UnityEngine;
//using System.Collections;

//public class Score : MonoBehaviour {

//    public static int score = 0;
//    void Awake()
//    {
//        Debug.Log("ScoreBeforeStart" + SaveValue.score);
//    }

//    // Use this for initialization
//    void Start () {
//        if (Application.loadedLevelName == "FrogStomach")
//            SaveValue.score = 0;
//        Debug.Log("ScoreAfterStart: " + SaveValue.score);
//    }

//    void OnDestroy()
//    {
//        Debug.Log("ScoreBeforeDestroy: " + SaveValue.score);
//    }
	
//    // Update is called once per frame
//    void Update () {
//        if(GameManager.gameOverScreen)
//            SaveValue.score = score;
//    }
//    void ResetScore() { PlayerPrefs.SetInt("PointsValue", 0); }

//    void SaveScore() 
//    { 
//        PlayerPrefs.SetInt("PointsValue", score);
//        if (score > GetHiScore())
//            PlayerPrefs.SetInt("HiScore", score);
//    }

//    public int GetScore() { return PlayerPrefs.GetInt("PointsValue"); }

//    public int GetHiScore() { return PlayerPrefs.GetInt("HiScore"); }
//}