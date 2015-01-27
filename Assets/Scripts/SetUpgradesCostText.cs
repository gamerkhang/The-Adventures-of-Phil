using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetUpgradesCostText : MonoBehaviour {
    GameObject parent;

    void Start()
    {
        parent = transform.parent.parent.parent.gameObject;
        DisplayPointsFor(parent.name);
    }

    void DisplayPointsFor(string upgrade)
    {
        string costDisplayed = GetComponent<Text>().text;
        SelectUpgrade parentUpgrade = parent.GetComponent<SelectUpgrade>();

        if (upgrade == "MultiShot")
            costDisplayed = parentUpgrade.multiCost.ToString();
        if (upgrade == "SpitFaster")
            costDisplayed = parentUpgrade.spitCost.ToString();
        if (upgrade == "SpeedBoost")
            costDisplayed = parentUpgrade.speedCost.ToString();
        if (upgrade == "ExtraHeart")
            costDisplayed = parentUpgrade.oneUpCost.ToString();

        GetComponent<Text>().text = costDisplayed;
    }
}
