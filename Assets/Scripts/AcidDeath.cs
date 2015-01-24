using UnityEngine;
using System.Collections;


public class AcidDeath : MonoBehaviour
{
    public GameObject splash;
    public Quaternion splashRotation;

    void Start()
    {
        splashRotation = splash.transform.rotation;
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Acid"))
        {
            GameObject temp = Instantiate(splash,splash.transform.position,splashRotation) as GameObject; //, new Vector3(transform.position.x, transform.position.y, 0, transform.rotation
            temp.SetActive(true);
            if(CompareTag("Player"))
                GameManager.lives -= 1;
            Destroy(temp,1f);
            Destroy(gameObject);
        }
    }
}
