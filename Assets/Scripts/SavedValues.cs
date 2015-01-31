using UnityEngine;
using System.Collections;

public class SavedValues : MonoBehaviour {

    public static int score;
    public static float time;
    public static bool multi;
    public static bool spit;
    public static bool speed;
    public static bool oneUp;
    public static bool mobile = false;

	void Awake()
    {
#if UNITY_ANDROID
        mobile = true;
#endif
        DontDestroyOnLoad(transform.gameObject);
    }

    public static void ResetValues()
    {
        score = 0;
        time = 0;
        multi = false;
        spit = false;
        speed = false;
        oneUp = false;
    }
}