using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
    Color targetColor;
    Color color;
    public string nextLevel;
    public float speed = 1.5f;
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
        //if (sceneEnding)
        //    EndScene();
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

    //void FadeToBlack()
    //{
    //    guiTexture.color = Color.Lerp(guiTexture.color, Color.black, speed * Time.deltaTime);
    //}
    //public void EndScene()
    //{
    //    sceneEnding = true;
    //    guiTexture.enabled = false;
    //    FadeToBlack();
    //    if(guiTexture.color.a >= 0.95f)
    //    {
    //        Application.LoadLevel(nextLevel);
    //    }
    //}
}
