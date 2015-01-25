using UnityEngine;
using System.Collections;

public class ApplicationModel : MonoBehaviour {

    public static int score = 0;

    //// Use this for initialization
    void Start()
    {
        score = PlayerPrefs.GetInt("PointsValue");
    }
	
    //// Update is called once per frame
    //void Update () {
	
    //}
}
