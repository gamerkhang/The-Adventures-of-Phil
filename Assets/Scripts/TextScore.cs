using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScore : MonoBehaviour {
	Text score;
	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "SCORE: " + ApplicationModel.score.ToString();
	}
}
