using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {
    public float speed = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnColliderEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            other.GetComponent<Rigidbody2D>().AddForce((transform.position - other.transform.position).normalized * speed);
    }
}
