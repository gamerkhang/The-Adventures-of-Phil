using UnityEngine;
using System.Collections;

public class SelectUpgrade : MonoBehaviour {
    string objName;
    public int multiCost;
    public int spitCost;
    public int speedCost;
    public int oneUpCost;

	void Start ()
    {
        objName = gameObject.name;
        GetCosts();
	}

    void GetCosts()
    {
        multiCost = GameObject.Find("MultiShot").GetComponent<SelectUpgrade>().multiCost;
        spitCost = GameObject.Find("MultiShot").GetComponent<SelectUpgrade>().spitCost;
        oneUpCost = GameObject.Find("MultiShot").GetComponent<SelectUpgrade>().oneUpCost;
        speedCost = GameObject.Find("MultiShot").GetComponent<SelectUpgrade>().speedCost;
    }

    void OnMouseDown()
    {
        if (SpendPoints())
            Destroy(GameObject.Find("Upgrades"));
        else
            Debug.Log("Can't afford it.");
    }

    bool SpendPoints()
    {
        switch (objName)
        {
            case "MultiShot":
                if (!CanAfford(multiCost))
                    return false;
                SavedValues.multi = true;
                SavedValues.score -= multiCost;
                return true;
            case "SpitFaster":
                if (!CanAfford(spitCost))
                    return false;
                SavedValues.spit = true;
                SavedValues.score -= spitCost;
                return true;
            case "ExtraHeart":
                if (!CanAfford(oneUpCost))
                    return false;
                SavedValues.oneUp = true;
                SavedValues.score -= oneUpCost;
                return true;
            case "SpeedBoost":
                if (!CanAfford(speedCost))
                    return false;
                SavedValues.speed = true;
                SavedValues.score -= speedCost;
                return true;
        }
        return false;
    }

    bool CanAfford(int value)
    {
        return SavedValues.score > value;
    }
}