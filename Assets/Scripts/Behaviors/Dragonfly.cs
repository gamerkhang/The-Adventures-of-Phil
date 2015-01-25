using UnityEngine;
using System.Collections;

public class Dragonfly : MonoBehaviour {
	const float FLYSPEED = 5;
	
	float symmrand(float v){return (Random.value-.5f)*v*2;}
	float rand(float a,float b){return a+Random.value*(b-a);}
	bool randchance(float c){return Random.value < c;}
	int randsign(){return randchance(.5f) ? -1 : 1;}
	float NormalAngle(float a){
		a = a%(Mathf.PI*2);
		return a < 0 ? a+Mathf.PI*2 : a;
	}
	float AngleDistance(float r0,float r1){
		r0 = NormalAngle(r0);
		r1 = NormalAngle(r1);
		float dist = Mathf.Abs(r0-r1);
		return dist > Mathf.PI ? Mathf.PI*2-dist : dist;
	}
	float LerpAngle(float r0,float r1,float lerp){
		r0 = NormalAngle(r0);
		r1 = NormalAngle(r1);
		if(r0 < r1 && r1-r0 > Mathf.PI)
			return NormalAngle((r0+Mathf.PI*2)*(1-lerp)+r1*lerp);
		else if(r0 > r1 && r0-r1 > Mathf.PI)
			return NormalAngle(r0*(1-lerp)+(r1+Mathf.PI*2)*lerp);
		return r0*(1-lerp)+r1*lerp;
	}

	float horizontalflight;
	float gravitymod;
	float sizex;
	void Start(){
		gravitymod = rand(.75f,.85f);
		horizontalflight = FLYSPEED*randsign();
		sizex = transform.localScale.x;
	}

	float turncooldown = 0;
	void OnCollisionEnter2D(Collision2D hit){
		if(turncooldown > 0) return;
		horizontalflight *= -1;
		turncooldown = rand(.8f,2f);
	}
	
	void Update(){
		if (gameObject.GetComponent<KillEnemy>().enemyAlive == false)
			enabled = false;
		if(turncooldown > 0)
			turncooldown -= Time.deltaTime;
		rigidbody2D.gravityScale *= gravitymod;//Mathf.Pow(gravitymultpersecond,Time.deltaTime);
		rigidbody2D.angularVelocity *= .98f;
		transform.rotation = Quaternion.Euler(0,0,LerpAngle(transform.rotation.eulerAngles.z,0,.005f));
		transform.localScale = new Vector3(sizex*(rigidbody2D.velocity.x > 0 ? 1 : -1),transform.localScale.y,0);
		if(rigidbody2D.gravityScale < .1f || rigidbody2D.velocity.y > -1){
			//if(rigidbody2D.velocity.y > -.5f)
				rigidbody2D.velocity = new Vector2(horizontalflight,rigidbody2D.velocity.y*.9f);
			/*else
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,rigidbody2D.velocity.y*.9f);*/
		}else
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,rigidbody2D.velocity.y*.9f);
	}
}
