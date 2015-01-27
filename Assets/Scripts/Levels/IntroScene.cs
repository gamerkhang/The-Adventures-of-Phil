using UnityEngine;
using System.Collections;

public class IntroScene : MonoBehaviour {
	public string nextLevel;
	public GameObject tongue;
    public AudioClip ribbit;
	GameObject tongueTemp;
	GameObject player;

	public float tongueSpeed = 10f;
    public float tongueSpawnY = 10f;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
		player = GameObject.Find("Phil");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject != null && other.gameObject.CompareTag("Player"))
		{
            tongueTemp = Instantiate(tongue, new Vector2(other.transform.position.x,other.transform.position.y - tongueSpawnY), tongue.transform.rotation) as GameObject;
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
        audio.PlayOneShot(ribbit);
        player.transform.parent = tongueTemp.transform;
        GameObject.Find("Follow Camera").GetComponent<FollowPhil>().enabled = false;
        StartCoroutine("EndLevel");
        //float newSpeed = tongueSpeed * Time.deltaTime;
        while (true)
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