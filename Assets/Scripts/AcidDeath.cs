﻿using UnityEngine;
using System.Collections;


public class AcidDeath : MonoBehaviour
{
    public GameObject splash;
    public Quaternion splashRotation;
    public AudioClip splashSound;

    void Start()
    {
        splashRotation = splash.transform.rotation;
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Acid"))
        {
            audio.PlayOneShot(splashSound);
            GameObject temp = Instantiate(splash, new Vector2(splash.transform.position.x, -4.122f), splashRotation) as GameObject;
            temp.SetActive(true);
            Destroy(temp, 0.5f);
            if (CompareTag("Player"))
                GameManager.beenHit = true;
            else
                Destroy(gameObject);
        }
    }
}
