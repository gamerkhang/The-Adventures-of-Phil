using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {
    int prevLives;
    int heartsIndex;
    public AudioClip rip;
	void Start ()
    {
        //PlayerPrefs.SetString("1UP","T");
        //if (PlayerPrefs.GetString("1UP") == "T")
        //{
        //    GameObject temp1 = new GameObject();
        //    GameObject temp2 = new GameObject();

        //    temp1 = Instantiate(transform.GetChild(0), new Vector2(-7.02f, 3.67f), Quaternion.identity) as GameObject;
        //    temp2 = Instantiate(transform.GetChild(1), new Vector2(-7.02f, 3.67f), Quaternion.identity) as GameObject;
        //    temp1.transform.parent = gameObject.transform.parent;
        //    //transform; //temp2.transform.parent = 
        //}
        heartsIndex = transform.childCount;
        prevLives = GameManager.lives;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (prevLives > GameManager.lives)
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
