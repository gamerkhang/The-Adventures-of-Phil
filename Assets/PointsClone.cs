using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsClone : MonoBehaviour 
{

    public int pointValue = 0;
    public float speed = 1f;
    float rate;
    Text pointText;
    RectTransform pointPos;

	void Start ()
    {
        pointText = GetComponentInChildren<Text>();
        if(pointValue < 0)
            pointText.text = pointValue.ToString();
        else
            pointText.text = "+" + pointValue.ToString();
	}

	void Update () 
    {
        if (pointText.color.a > 0.05f)
            pointText.color -= Color.black * speed * Time.deltaTime;
        else
            Destroy(this.gameObject);
	}
}