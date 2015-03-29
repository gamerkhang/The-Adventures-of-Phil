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
        GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }
	void Update () 
    {
        if(sceneStarting)
            StartScene();
	}
	void FadeToClear()
    {
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, speed * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();

        if(GetComponent<GUITexture>().color.a <= 0.05f)
        {
            GetComponent<GUITexture>().color = Color.clear;
            GetComponent<GUITexture>().enabled = false;
            sceneStarting = false;
        }
    }
}
