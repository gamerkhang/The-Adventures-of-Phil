using UnityEngine;
using System.Collections;

public class IntroScene : MonoBehaviour {
	public string nextLevel;
	public float startDelay = 5.0f;
	public GameObject tongue;
	GameObject tongueTemp;
	GameObject player;
	bool started = false;
    bool reachedPlayer = false;

	public float tongueSpeed = 10f;
    Vector3 originalPos;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Phil");
<<<<<<< HEAD
        originalPos = tongue.transform.position;
=======
//		tongue = GameObject.Find("Tongue");
//		tongueTemp.transform.LookAt (player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if(started)
		{
			float tongueHeight = (tongueTemp.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2);
			Vector3 tongueVector = new Vector3(0f,tongueHeight,0f);
			Debug.Log("wqer");
			tongueTemp.transform.position = Vector3.Lerp(tongueTemp.transform.position,player.transform.position - tongueVector

			                                         ,tongueSpeed*Time.deltaTime);
		}
//		for (float i = 0f; i < startDelay; i++)
//		{
//			
//		}
//		Application.LoadLevel(nextLevel);

	}

	float GetAngle(Vector2 from,Vector2 to){
		Vector2 a = to-from;
		return Mathf.Atan(a.y/a.x)*180/Mathf.PI;
>>>>>>> origin/master
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject != null && other.gameObject.CompareTag("Player"))
		{
<<<<<<< HEAD
            tongueTemp = Instantiate(tongue, new Vector2(other.transform.position.x,tongue.transform.position.y), tongue.transform.rotation) as GameObject;
=======
			tongueTemp = Instantiate (tongue,new Vector3(0f,-58.9f,0f),tongue.transform.rotation) as GameObject;
			tongue.transform.rotation = Quaternion.Euler(0,0,GetAngle(tongue.transform.position, player.transform.position)+180);
			started = true;
>>>>>>> origin/master
			player.GetComponent<Movement>().enabled = false;
			player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine("MoveTongue");
		}
	}

    IEnumerator MoveTongue()
    {
        while (tongueTemp.transform.position.y < player.transform.position.y)
        {
            tongueTemp.transform.position += tongueSpeed*Vector3.up*Time.deltaTime; //Vector3.Lerp(tongueTemp.transform.position, player.transform.position, tongueSpeed * Time.deltaTime)
            yield return null;
        }
        //yield return null;
        player.transform.parent = tongueTemp.transform;
        GameObject.Find("Follow Camera").GetComponent<FollowPhil>().enabled = false;
        StartCoroutine("EndLevel");
        //float newSpeed = tongueSpeed * Time.deltaTime;
        while (true) //tongueTemp.transform.position.y player.transform.position.y > originalPos.y
        {
            tongueTemp.transform.position -= tongueSpeed/15 * Vector3.up; // * Time.deltaTime
            yield return null;
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(nextLevel);
    }
}

//float GetAngle(Vector2 from,Vector2 to){
//    Vector2 a = to-from;
//    return Mathf.Atan(a.y/a.x)*180/Mathf.PI;
//}
