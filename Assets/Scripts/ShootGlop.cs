using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootGlop : MonoBehaviour {

    public GameObject glop;
    public float glopSpeed = 5f;
    public static List<GameObject> glopList;
    float yMax = 7.5f;
    public AudioClip spit;

	// Use this for initialization
    void Start()
    {
        glopList = new List<GameObject>();
	}
	
	// Update is called once per frame
    float cooldown;
	void Update () {

        if (GameManager.gameRunning)
        {
            if (cooldown > 0)
                cooldown -= Time.deltaTime;
            else if (Input.GetButtonDown("Fire1"))
                FireGlop();
        }
	}

    void FireGlop()
    {
        if (glopList.Count <= 5)
        {
            cooldown = 1f;

            GameObject temp = Instantiate(glop, transform.position, glop.transform.rotation) as GameObject;
            temp.rigidbody2D.velocity = Vector3.up * glopSpeed;
            glopList.Add(temp);
            audio.PlayOneShot(spit);
        }
    }
}
