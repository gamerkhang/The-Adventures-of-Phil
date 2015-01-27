using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootGlop : MonoBehaviour {

    public GameObject glop;
    public float glopSpeed = 5f;
    //public static List<GameObject> glopList;
    public AudioClip spit;
    bool multi = false;
    public float cDown = 1f;

    void Start()
    {
        if (SaveValue.spit)
            cDown /= 2;
        else
            cDown = 1f;
        if (SaveValue.multi)
            multi = true;
        else
            multi = false;
        //glopList = new List<GameObject>();
	}
	
	// Update is called once per frame
    float cooldown;
	void Update () {

        if (GameManager.gameRunning)
        {
            if (cooldown > 0)
                cooldown -= Time.deltaTime;
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
            //glopList.Add(temp);
        } 
        else
        {
            GameObject temp = Instantiate(glop, transform.position, glop.transform.rotation) as GameObject;
            temp.rigidbody2D.velocity = Vector3.up * glopSpeed;
            //glopList.Add(temp);
        }
        audio.PlayOneShot(spit);
    }
}
