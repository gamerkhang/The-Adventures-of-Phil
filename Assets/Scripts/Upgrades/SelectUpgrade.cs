using UnityEngine;
using System.Collections;

public class SelectUpgrade : MonoBehaviour {
    string objName;
    public int multiCost = 4000;
    public int spitCost = 3500;
    public int speedCost = 3500;
    public int oneUpCost = 2000;

	void Start ()
    {
        objName = gameObject.name;
	}

    void OnMouseDown()
    {
        if(SpendPoints())
		    Destroy(GameObject.Find ("Upgrades"));
    }

    bool SpendPoints()
    {
        switch (objName)
        {
            case "MultiShot":
                SaveValue.multi = true;
                SaveValue.score -= multiCost;
                return true;
            case "SpitFaster":
                SaveValue.spit = true;
                SaveValue.score -= spitCost;
                return true;
            case "ExtraHeart":
                SaveValue.oneUp = true;
                SaveValue.score -= oneUpCost;
                return true;
            case "SpeedBoost":
                SaveValue.speed = true;
                SaveValue.score -= speedCost;
                return true;
        }
        return false;
    }
}