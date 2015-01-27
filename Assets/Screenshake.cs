using UnityEngine;
using System.Collections;
public class Screenshake : MonoBehaviour{
	public float Amount;
	void Start(){}
	void Update(){
		if((Amount *= .95f) < .3f)
			GameObject.Destroy(this);
		Camera.main.transform.position = Camera.main.transform.position*.75f+new Vector3((Random.value-.5f)*Amount,(Random.value-.5f)*Amount,Camera.main.transform.position.z)*.25f;
	}
}