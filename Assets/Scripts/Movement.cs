using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Vector3 curPos;
    Vector3 mousePos;
    public float speed;
    float zPos;
	// Use this for initialization
	void Start () {
        zPos = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.Lerp(transform.position, mousePos, speed * Time.deltaTime);
        //transform.position += (mousePos - curPos).normalized * speed * Time.deltaTime;
	}
    void FixedUpdate()
    {
        curPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = zPos;
        rigidbody2D.AddForce((mousePos - curPos).normalized * speed);
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Right")
    //        transform.position += Vector3.left;
    //}
}
