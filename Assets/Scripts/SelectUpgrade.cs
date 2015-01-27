using UnityEngine;
using System.Collections;

public class SelectUpgrade : MonoBehaviour {
    string objName;
    GameObject player;
	// Use this for initialization
	void Start () {
        objName = gameObject.name;
        player = GameObject.Find("Phil");
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
                PlayerPrefs.SetString("Multi", "T");
                break;
            case "SpitFaster":
                //BestowSpitBoost();
                PlayerPrefs.SetString("Spit", "T");
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
		Destroy(GameObject.Find ("Upgrades"));
    }
}
