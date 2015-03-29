using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {
    int prevLives;
    int heartsIndex;
    public AudioClip rip;
    public int scoreDecrease = -500;

	// Use this for initialization
	void Start () 
    {
        heartsIndex = transform.childCount;
        prevLives = GameManager.lives;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (prevLives > GameManager.lives)
        {
            if (--heartsIndex >= 0)
            {
                Transform heartAtIndex = transform.GetChild(heartsIndex);
				heartAtIndex.gameObject.SetActive(false);
				GetComponent<AudioSource>().PlayOneShot(rip);
                //SavedValues.score += scoreDecrease;

                InstantiatePointsClone(heartAtIndex.position);
            }
        }
        prevLives = GameManager.lives;
	}

    void InstantiatePointsClone(Vector3 pos)
    {
        GameObject pointsClone = (GameObject)Resources.Load("pointsget", typeof(GameObject));
        pointsClone.GetComponent<PointsClone>().pointValue = scoreDecrease;
        Instantiate(pointsClone, pos, Quaternion.identity);
    }
}
