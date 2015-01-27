using UnityEngine;
using System.Collections;

public class KillPhil : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.beenHit = true;
        }
    }
}
