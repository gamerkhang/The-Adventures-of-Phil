using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTimer : MonoBehaviour {
	Text timer;
	// Use this for initialization
	void Start () {
		timer = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = "POOR PHIL LIVED FOR\n" + GameManager.minutes + " minutes, " + GameManager.seconds + " seconds...";
	}
}
