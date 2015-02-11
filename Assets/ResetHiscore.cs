using UnityEngine;
using System.Collections;

public class ResetHiscore : MonoBehaviour
{
    public int value = 10000;
    void Awake()
    {
        PlayerPrefs.SetInt("HighScore", value);
    }
}