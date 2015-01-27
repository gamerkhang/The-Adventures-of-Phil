using UnityEngine;
using System.Collections;

public class Mosquito : MonoBehaviour {
	const float FLYSPEED = 3;
	const float BACKUPSPEED = 2;
	const float CHARGESPEED = 10;
	const float CHARGE = 1.5f;
    GameObject player;
	
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
	float ToAngle(Vector2 v){
		return Mathf.Atan(v.y/v.x);
	}
	
	float horizontalflight;
	float gravitymod;
	float sizex;
	float ChargeTimer;
	bool Charging;
	float chargecooldown;
	void Start(){
        player = (GameObject)GameObject.FindWithTag("Player");
		chargecooldown = rand(1,4)+rand(1,4)+rand(1,4);
		Charging = false;
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

	void FaceDir(Vector2 v){
		transform.localScale = new Vector3(sizex*(v.x > 0 ? 1 : -1),transform.localScale.y,0);
	}

	Vector2 GetPlayerPosition(){
		return (player).transform.position;
	}

	Vector3 ChargeToward;
	void Update_Charging(){
		Vector3 targetpos = GetPlayerPosition();
		Vector2 diff = (targetpos-transform.position).normalized;
		if(ChargeTimer > 0){
			//transform.rotation = Quaternion.Euler(0,0,ToAngle(targetpos-transform.position)*180/Mathf.PI*(Mathf.Sign(transform.localScale.x)));
			if((ChargeTimer -= Time.deltaTime) <= 0)
				ChargeToward = (Vector2)transform.position+diff*10000;
			rigidbody2D.velocity = -diff*BACKUPSPEED;
		}else{
			ChargeTimer -= Time.deltaTime;
			rigidbody2D.velocity = (ChargeToward-transform.position).normalized*CHARGESPEED;
			if(ChargeTimer < -2){
				chargecooldown = rand(1,3);
				Charging = false;
			}
		}
	}
	
	void Update(){
		if(turncooldown > 0)
			turncooldown -= Time.deltaTime;
		rigidbody2D.gravityScale *= gravitymod;//Mathf.Pow(gravitymultpersecond,Time.deltaTime);
		
		rigidbody2D.angularVelocity *= .95f;

		if(Charging && player != null){
			Update_Charging();
			return;
		}

		transform.rotation = Quaternion.Euler(0,0,LerpAngle(transform.rotation.eulerAngles.z,0,.01f));

		if((chargecooldown -= Time.deltaTime) <= 0){
			ChargeTimer = CHARGE;
			Charging = true;
		}
		FaceDir(rigidbody2D.velocity);
		if(rigidbody2D.gravityScale < .1f || rigidbody2D.velocity.y > -1){
			rigidbody2D.velocity = new Vector2(horizontalflight,rigidbody2D.velocity.y*.9f);
		}else
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,rigidbody2D.velocity.y*.9f);
	}
}
