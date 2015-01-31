using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTester : MonoBehaviour
{
    public GameObject test;
    Text testText;
    int prevScore;
    int newScore;
	// Use this for initialization
	void Start () 
    {
	    testText = test.GetComponent<Text>();
        prevScore = SavedValues.score;
        newScore = prevScore;
	}
	
    int deltaScore;
	// Update is called once per frame
	void Update () 
    {
        newScore = SavedValues.score;
        deltaScore = newScore - prevScore;
	    if(deltaScore > 50)
        {
            testText.text = deltaScore.ToString();
        }
        prevScore = newScore;
	}
}