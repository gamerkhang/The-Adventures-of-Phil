using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {
    int prevLives;
    int heartsIndex;
	// Use this for initialization
	void Start () 
    {
        heartsIndex = transform.childCount;
        prevLives = GameManager.lives;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(prevLives>GameManager.lives)
        {
            heartsIndex--;
            (transform.GetChild(heartsIndex)).gameObject.SetActive(false);
        }
        prevLives = GameManager.lives;
	}
}
