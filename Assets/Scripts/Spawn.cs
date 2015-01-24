using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public float enemyFlySpawnTime = 3f;
    public GameObject enemyFly;
    Vector2 ranForce;


	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnFly");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnFly()
    {
        while (true)
        {
            ranForce.x = Random.Range(-300, 300);
            ranForce.y = Random.Range(-10, -100);

            GameObject temp = Instantiate(enemyFly) as GameObject;
            temp.rigidbody2D.AddForce(ranForce);
            yield return new WaitForSeconds(enemyFlySpawnTime);
        }
    }
}
