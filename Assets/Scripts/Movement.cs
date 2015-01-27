using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
    Vector3 curPos;
    Vector3 mousePos;
    Vector3 rotation;
    public float speed = 5.53f;
    float zPos;
    Quaternion up;
    Quaternion down;
    HashSet<string> levelsYFlip;
    string thisLevel;
    void Awake()
    {
        thisLevel = Application.loadedLevelName;
        levelsYFlip = new HashSet<string>();
        levelsYFlip.Add("Transition1");
        levelsYFlip.Add("Transition2");
        levelsYFlip.Add("Intro");
        levelsYFlip.Add("Credits");
        up = new Quaternion(0f, 0f, 0f, 0f);
        down = new Quaternion(0f, 0f, 180f, 0f);
    }
	// Use this for initialization
	void Start () {
        zPos = transform.position.z;
        float origSpeed = speed;
        if (SaveValue.speed == true)
            speed *= 2;
        else
            speed = origSpeed;
	}
	
    void FixedUpdate()
    {
        curPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = zPos;
        rotation = (mousePos - curPos).normalized;
        FlipY();
        if ((transform.position - mousePos).magnitude < .15f)
            transform.position = mousePos;
        else
            rigidbody2D.velocity = rotation * speed;
    }

    void FlipY()
    {
        if (levelsYFlip.Contains(thisLevel))
        {
            if (mousePos.y > curPos.y)
                transform.rotation = up;
            else
                transform.rotation = down;
        }
    }
}
