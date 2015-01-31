using UnityEngine;
using System.Collections;

public class ResetHiscore : MonoBehaviour
{

    void Awake()
    {
        PlayerPrefs.SetInt("HighScore", 10000);
    }
}