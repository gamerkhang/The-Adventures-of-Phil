using UnityEngine;
using System.Collections;

public class ResetUpgrades : MonoBehaviour 
{
    void Awake()
    {
        SavedValues.ResetValues();
    }
}
