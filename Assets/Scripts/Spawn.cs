using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public float enemyFlySpawnTime = 3f;
    public float timeTilStart = 2f;
    public GameObject enemyFly;
    Vector2 ranForce;
    public int numFlies = 10;

    GameObject nextLevel;


	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnFly");
        nextLevel = GameObject.FindWithTag("NextLevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnFly()
    {
        yield return new WaitForSeconds(timeTilStart);
        for (int i = 0; i < numFlies; ++i )
        {
            ranForce.x = Random.Range(-300, 300);
            ranForce.y = Random.Range(-10, -100);

            GameObject temp = Instantiate(enemyFly) as GameObject;
            temp.rigidbody2D.AddForce(ranForce);
            yield return new WaitForSeconds(enemyFlySpawnTime);
        }
        GameManager.gameOver = true;
        nextLevel.GetComponent<EdgeCollider2D>().enabled = true;
    }
}
