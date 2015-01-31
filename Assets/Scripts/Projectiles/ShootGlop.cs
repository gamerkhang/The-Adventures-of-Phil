using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootGlop : MonoBehaviour {

    public GameObject glop;
    public float glopSpeed = 5f;
    public AudioClip spit;
    bool multi = false;
    public float cDown = 1f;

    void Start()
    {
        if (SavedValues.spit)
            cDown /= 2;
        else
            cDown = 1f;
        if (SavedValues.multi)
            multi = true;
        else
            multi = false;
	}
	
	// Update is called once per frame
    float cooldown;
	void Update () {

        if (GameManager.gameRunning)
        {
            if (cooldown > 0)
                cooldown -= Time.deltaTime;
            else if (SavedValues.mobile && Input.touchCount > 0) // && Input.GetTouch(0).phase == TouchPhase.Began
                FireGlop();
            else if (Input.GetButton("Fire1"))
                FireGlop();
        }
	}

    void FireGlop()
    {
        cooldown = cDown;
        if (multi)
        {
            GameObject temp = Instantiate(glop, transform.position + Vector3.up / 4, glop.transform.rotation) as GameObject;
            GameObject temp2 = Instantiate(glop, transform.position - Vector3.right / 2 + Vector3.up / 4, glop.transform.rotation * Quaternion.Euler(0, 0, 45)) as GameObject;
            GameObject temp3 = Instantiate(glop, transform.position + Vector3.right / 2 + Vector3.up / 4, glop.transform.rotation * Quaternion.Euler(0, 0, -45)) as GameObject;
            temp.rigidbody2D.velocity = new Vector2(0, 1) * glopSpeed;
            temp2.rigidbody2D.velocity = new Vector2(-0.10f, 1) * glopSpeed;
            temp3.rigidbody2D.velocity = new Vector2(0.10f, 1) * glopSpeed;
        } 
        else
        {
            GameObject temp = Instantiate(glop, transform.position, glop.transform.rotation) as GameObject;
            temp.rigidbody2D.velocity = Vector3.up * glopSpeed;
        }
        audio.PlayOneShot(spit);
    }
}
