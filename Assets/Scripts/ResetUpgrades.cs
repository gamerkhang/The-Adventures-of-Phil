using UnityEngine;
using System.Collections;

public class ResetUpgrades : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("Multi", "F");
        PlayerPrefs.SetString("Spit", "F");
        PlayerPrefs.SetString("1UP", "F");
        PlayerPrefs.SetString("Speed", "F");
	}
    void Update()
    {
        PlayerPrefs.SetString("Multi", "F");
        PlayerPrefs.SetString("Spit", "F");
        PlayerPrefs.SetString("1UP", "F");
        PlayerPrefs.SetString("Speed", "F");

    }
}
