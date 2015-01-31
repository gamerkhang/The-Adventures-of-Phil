using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HiScoreText : MonoBehaviour {

	void Start () {
        GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
	}
}
