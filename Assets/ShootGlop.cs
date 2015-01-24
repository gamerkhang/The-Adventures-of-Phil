using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootGlop : MonoBehaviour {

    public GameObject glop;
    public float glopSpeed = 5f;
    List<GameObject> glopList;
    float yMax = 7.5f;

	// Use this for initialization
    void Start()
    {
        glopList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            FireGlop();
	}

    void FireGlop()
    {
        if (glopList.Count <= 5)
        {
            GameObject temp = Instantiate(glop, transform.position, transform.rotation) as GameObject;
            temp.rigidbody2D.velocity = Vector3.up * glopSpeed;
            glopList.Add(temp);
        }
    }
}
