using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Vector3 curPos;
    Vector3 mousePos;
    Vector3 rotation;
    public float speed = 6f;
    public float rotateSpeed = 5f;
    float zPos;
	// Use this for initialization
	void Start () {
        zPos = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        //float h = Input.GetAxis("Mouse X") * rotateSpeed;
        //float z = Input.GetAxis("Mouse X") * rotateSpeed;
        //transform.Rotate(0, 0, -z);
	}
    void FixedUpdate()
    {
        curPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = zPos;
        rotation = (mousePos - curPos).normalized;
        rigidbody2D.velocity = rotation * speed;
    }
}
