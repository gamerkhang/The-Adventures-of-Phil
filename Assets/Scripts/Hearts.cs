using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {
    int prevLives;
    int heartsIndex;
    public AudioClip rip;
	// Use this for initialization
	void Start () 
    {
        heartsIndex = transform.childCount;
        prevLives = GameManager.lives;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (prevLives > GameManager.lives) // && (!GameManager.gameOver && GameManager.gameRunning)
        {
            heartsIndex--;
            if (heartsIndex >= 0)
            {
                Transform heartAtIndex = transform.GetChild(heartsIndex);
                heartAtIndex.gameObject.SetActive(false);
            }
            audio.PlayOneShot(rip);
        }
        prevLives = GameManager.lives;
	}
}
