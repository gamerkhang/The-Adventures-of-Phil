using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScore : MonoBehaviour {
	Text score;
    bool inStomach = false;

	void Start () {
        if (Application.loadedLevelName != "Credits")
            inStomach = true;
		score = GetComponent<Text>();
        score.text = SavedValues.score.ToString();
	}
	
	void Update () {
        if (inStomach && !GameManager.gameOverScreen)
		    score.text = "SCORE: " + SavedValues.score.ToString();
	}

    //IEnumerator FadeToVisible()
    //{
    //    //not used currently
    //    guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, speed * Time.deltaTime);
    //    if (guiTexture.color.a <= 0.05f)
    //    {
    //        guiTexture.color = Color.clear;
    //        guiTexture.enabled = false;
    //    }
    //    yield return null;
    //}
}
