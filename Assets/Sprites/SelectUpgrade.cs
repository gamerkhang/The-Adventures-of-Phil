using UnityEngine;
using System.Collections;

public class SelectUpgrade : MonoBehaviour {
    string objName;
    GameObject player;
    int points;
	// Use this for initialization
	void Start () {
        objName = gameObject.name;
        player = GameObject.Find("Phil");
        points = PlayerPrefs.GetInt("PointsValue");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        switch(objName)
        {
            case "MultiShot":
                //BestowMultishot();
                if (points >= 4000)
                {
                    PlayerPrefs.SetString("Multi", "T");
                    PlayerPrefs.SetInt("PointsValue", points - 4000);
                }
                break;
            case "SpitFaster":
                //BestowSpitBoost();
                if (points >= 4000)
                {
                    PlayerPrefs.SetString("Spit", "T");
                    PlayerPrefs.SetInt("PointsValue", points - 4000);
                }
                break;
            case "ExtraHeart":
                //Bestow1UP();
                PlayerPrefs.SetString("1UP", "T");
                break;
            case "SpeedBoost":
                //BestowSpeedBoost();
                PlayerPrefs.SetString("Speed", "T");
                break;
        }
        Destroy(gameObject);
    }
}
