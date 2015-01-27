using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
    public string nextLevel;
    public static float speed = 1.5f;
    bool sceneStarting = true;
    //bool sceneEnding = false;

    void Awake()
    {
        GetComponent<GUITexture>().enabled = true;
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }
	void Update () 
    {
        if(sceneStarting)
            StartScene();
	}
	void FadeToClear()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, speed * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();

        if(guiTexture.color.a <= 0.05f)
        {
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;
            sceneStarting = false;
        }
    }
}
