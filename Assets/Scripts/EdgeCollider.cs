using UnityEngine;
using System.Collections;

public class EdgeCollider : MonoBehaviour {
    public bool on = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            ShootGlop.glopList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
