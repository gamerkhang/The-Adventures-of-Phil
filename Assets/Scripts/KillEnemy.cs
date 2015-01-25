using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{
    public AudioClip spitHit;
    public int scoreIncrease;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            ApplicationModel.score += scoreIncrease;
            audio.PlayOneShot(spitHit);
        }
    }
}
