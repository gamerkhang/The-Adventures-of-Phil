using UnityEngine;
using System.Collections;


public class AcidDeath : MonoBehaviour
{
    public GameObject splash;
    Quaternion splashRotation;
    public AudioClip splashSound;

    void Start()
    {
        splashRotation = splash.transform.rotation;
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Acid"))
        {
            GetComponent<AudioSource>().PlayOneShot(splashSound);
            GameObject temp = Instantiate(splash, new Vector2(transform.position.x, -4.122f), splashRotation) as GameObject; //splash.
            temp.SetActive(true);
            Destroy(temp, 0.5f);
            if (CompareTag("Player"))
			{
				if (GameManager.lives <= 0)
					Destroy(gameObject);
                GameManager.beenHit = true;
			}
            else
                Destroy(gameObject);
        }
    }

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Acid"))
		{
			//audio.PlayOneShot(splashSound);
			GameObject temp = Instantiate(splash, new Vector2(transform.position.x, -4.122f), splashRotation) as GameObject; //splash.
			temp.SetActive(true);
			Destroy(temp, 0.5f);
			if (CompareTag("Player"))
			{
				GameManager.beenHit = true;
				if (GameManager.lives <= 0)
					Destroy(gameObject);
			}
			else
				Destroy(gameObject);
		}
	}
}
