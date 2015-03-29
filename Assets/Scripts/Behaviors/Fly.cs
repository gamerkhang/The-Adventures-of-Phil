using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {
	float flyspeed;
	bool canfly;
	
	float symmrand(float v){return (Random.value-.5f)*v*2;}
	float rand(float a,float b){return a+Random.value*(b-a);}
	bool randchance(float c){return Random.value < c;}
	int randsign(){return randchance(.5f) ? -1 : 1;}
		                                 
	void Start(){
		if(randchance(.25f)){
			GetComponent<Rigidbody2D>().AddTorque(rand(25,50)*randsign());
			canfly = true;
			flyspeed = rand(1750,2500);
			GetComponent<Rigidbody2D>().gravityScale = .25f;
		}else
			GetComponent<Rigidbody2D>().AddTorque(symmrand(50));
	}

	void Update(){
		if (gameObject.GetComponent<KillEnemy>().enemyAlive == false)
			enabled = false;
		if(canfly){
			GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(flyspeed*Time.deltaTime,0));
			flyspeed *= .975f;
		}
	}
}
