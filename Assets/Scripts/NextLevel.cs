using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
    public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            Application.LoadLevel(nextLevel);
        }
    }
}
