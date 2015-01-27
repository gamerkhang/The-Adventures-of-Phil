using UnityEngine;
using System.Collections;

public class Moth : MonoBehaviour {
	const float FLYSPEED = 5;
	const float MOVEMENTRAND = .1f;

	float symmrand(float v){return (Random.value-.5f)*v*2;}
	float rand(float a,float b){return a+Random.value*(b-a);}
	bool randchance(float c){return Random.value < c;}
	int randsign(){return randchance(.5f) ? -1 : 1;}

	Vector2 movementnormal;
	float sizex;
	void Start(){
		//rigidbody2D.gravityScale = .1f;
		sizex = transform.localScale.x;
		movementnormal = new Vector2(symmrand(1),symmrand(1));
	}

	void Update(){
		if (gameObject.GetComponent<KillEnemy>().enemyAlive == false)
			enabled = false;
		movementnormal = (movementnormal+new Vector2(symmrand(MOVEMENTRAND),symmrand(MOVEMENTRAND))).normalized;
		rigidbody2D.angularVelocity = 0;
		transform.localScale = new Vector3(sizex*(movementnormal.x > 0 ? 1 : -1),transform.localScale.y,0);
		//rigidbody2D.AddForce(new Vector2(movementnormal.x*(FLYSPEED*Time.deltaTime),0));
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x+movementnormal.x*(FLYSPEED*Time.deltaTime),-2);
	}
}
