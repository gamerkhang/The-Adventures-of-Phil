using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{
    public AudioClip spitHit;
    public int scoreIncrease;
	public bool enemyAlive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
			gameObject.rigidbody2D.gravityScale = 2f;
            audio.PlayOneShot(spitHit);
			enemyAlive = false;
			ApplicationModel.score += scoreIncrease;
            audio.PlayOneShot(spitHit);
        }
    }
}
