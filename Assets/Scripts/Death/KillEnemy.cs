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
            if (enemyAlive)
            {
                gameObject.rigidbody2D.gravityScale = 2f;
                GetComponent<SpriteRenderer>().color = new Color(166f/255f, 223f/255f, 105f/255f);
                SavedValues.score += scoreIncrease;
                InstantiatePointsClone();
            }
            audio.PlayOneShot(spitHit);
			enemyAlive = false;
        }
    }

    void InstantiatePointsClone()
    {
        GameObject pointsClone = new GameObject();
        pointsClone = (GameObject)Resources.Load("pointsget", typeof(GameObject));
        pointsClone.GetComponent<PointsClone>().pointValue = scoreIncrease;
        Instantiate(pointsClone, transform.position, Quaternion.identity);
    }
}
