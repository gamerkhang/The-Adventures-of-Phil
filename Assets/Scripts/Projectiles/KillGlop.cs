using UnityEngine;
using System.Collections;

public class KillGlop : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            //ShootGlop.glopList.Remove(gameObject);
            Destroy(gameObject,0.01f);
        }
    }
}
