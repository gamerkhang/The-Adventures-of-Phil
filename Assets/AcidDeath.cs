using UnityEngine;
using System.Collections;


public class AcidDeath : MonoBehaviour
{
    public GameObject splash;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Acid"))
        {
            GameObject temp = Instantiate(splash,splash.transform.position,splash.transform.rotation) as GameObject; //, new Vector3(transform.position.x, transform.position.y, 0, transform.rotation
            temp.SetActive(true);
            Destroy(temp,1f);
            Destroy(gameObject);
        }
    }
}
