using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScore : MonoBehaviour {
	Text score;
    float speed = FadeIn.speed;

	void Start () {
		score = GetComponent<Text>();
	}
	
	void Update () {
        if (!GameManager.gameOverScreen)
		    score.text = "SCORE: " + SaveValue.score.ToString();
	}

    IEnumerator FadeToVisible()
    {
        //not used currently
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, speed * Time.deltaTime);
        if (guiTexture.color.a <= 0.05f)
        {
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;
        }
        yield return null;
    }
}
