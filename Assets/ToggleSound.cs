using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour 
{

	void Awake () 
    {
#if !UNITY_WEBPLAYER
        GetComponent<AudioSource>().enabled = true;
#endif
	}
}