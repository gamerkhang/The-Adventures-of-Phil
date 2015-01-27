using UnityEngine;
using System.Collections;

public class SaveValue : MonoBehaviour {

    public static int score;
    public static float time;
    public static bool multi;
    public static bool spit;
    public static bool speed;
    public static bool oneUp;

	void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (Application.loadedLevelName == "FrogStomach")
            ResetValues();
    }

    void ResetValues()
    {
        score = 0;
        time = 0;
        multi = false;
        spit = false;
        speed = false;
        oneUp = false;
    }
}