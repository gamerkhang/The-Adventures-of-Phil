using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	float symmrand(float v){return (Random.value-.5f)*v*2;}
	float rand(float a,float b){return a+Random.value*(b-a);}
	bool randchance(float c){return Random.value < c;}
	int randsign(){return randchance(.5f) ? -1 : 1;}

    public static float timeTilStart = 4f;

    public GameObject[] Enemies;
	public float[] SpawnChancePerSecond;

    public int TotalEnemies = 10;

    GameObject nextLevel;

	// Use this for initialization
	float SpawnRateMultiplier = 1;
	void Start(){
        nextLevel = GameObject.FindWithTag("NextLevel");
	}
	
	// Update is called once per frame
    void Update()
    {
        if (timeTilStart > 0)
        {
            timeTilStart -= Time.deltaTime;
            return;
        }
		if(TotalEnemies <= 0) return;
		SpawnRateMultiplier *= Mathf.Pow(1.02f,Time.deltaTime);
		for(int i = 0; i < Enemies.Length; i++){
			if(randchance(SpawnChancePerSecond[i])){//Mathf.Pow(SpawnChancePerSecond[i],Time.deltaTime))){
				SpawnEnemy(i);
				break;
			}
		}
	}

    void SpawnEnemy(int index)
    {
		GameObject obj = Instantiate(Enemies[index]) as GameObject;
		obj.rigidbody2D.AddForce(new Vector2(symmrand(300),rand(-100,-10)));
		if(--TotalEnemies <= 0){
			GameManager.gameOver = true;
			nextLevel.GetComponent<EdgeCollider2D>().enabled = true;
		}
	}
}
