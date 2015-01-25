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
        timer.text = "Poor Phil lived for\n";
        if (GameManager.minutes != "00")
            timer.text += GameManager.minutes + " minutes, ";
        timer.text += GameManager.seconds + " seconds...";
	}
}
