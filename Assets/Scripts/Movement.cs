using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Vector3 curPos;
    Vector3 mousePos;
    Vector3 rotation;
    public float speed;
    float zPos;
	// Use this for initialization
	void Start () {
        zPos = transform.position.z;
        if (PlayerPrefs.GetString("Speed") == "T")
            speed *= 2;
        else
            speed = 5.53f;
	}
	
	// Update is called once per frame
	void Update () {
	}
    void FixedUpdate()
    {
        curPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = zPos;
        rotation = (mousePos - curPos).normalized;
		if((transform.position-mousePos).magnitude < .15f)
			transform.position = mousePos;
		else
        	rigidbody2D.velocity = rotation * speed;
    }
}
