using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	float symmrand(float v){return (Random.value-.5f)*v*2;}
	float rand(float a,float b){return a+Random.value*(b-a);}
	bool randchance(float c){return Random.value < c;}
	int randsign(){return randchance(.5f) ? -1 : 1;}

    public GameObject[] Enemies;
	public float[] SpawnChancePerSecond;

    public int TotalEnemies = 10;

    GameObject nextLevel;

	float SpawnRateMultiplier = 1;
	void Start(){
        nextLevel = GameObject.FindWithTag("NextLevel");
	}
	
    void Update()
    {
        if (GameObject.Find("ScreenShaker") != null) return;
		if(TotalEnemies <= 0) return;
		SpawnRateMultiplier *= Mathf.Pow(1.02f,Time.deltaTime);
		for(int i = 0; i < Enemies.Length; i++){
			if(randchance(SpawnChancePerSecond[i])){
				SpawnEnemy(i);
				break;
			}
		}
	}

    void SpawnEnemy(int index)
    {
		GameObject obj = Instantiate(Enemies[index]) as GameObject;
		obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(symmrand(300),rand(-100,-10)));
		if(--TotalEnemies <= 0){
			GameManager.gameOver = true;
            GetComponent<AudioSource>().Play();
            GetComponent<Screenshake>().enabled = true;
            nextLevel.GetComponent<EdgeCollider2D>().enabled = true;
		}
	}
}
