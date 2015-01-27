using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
    public string nextLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            Application.LoadLevel(nextLevel);
        }
    }
}
