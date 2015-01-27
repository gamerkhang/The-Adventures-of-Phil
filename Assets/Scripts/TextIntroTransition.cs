using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextIntroTransition : MonoBehaviour {
	Text intro;
	float nextTime;
	string introText1 = "Today is not a very good day for Phil… and to make" +
		" matters worse, as a fly, it is the only day he gets to live!";
	string introText2 = "Poor Phil";
	string introText3 = ". . .";
	string introText4 = "WHAT DO I DO NOW?!?!";
    public float transitionTime = 0.1f;
	public float startDelay = 1f;
    public string nextLevel;
    public AudioClip PhilTalk;
	int currentCase;
	int currentCharIndex;

	// Use this for initialization
	void Start () {
		intro = GetComponent<Text>();
		intro.text = "";
		currentCharIndex = 0;
		nextTime = startDelay + transitionTime + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextTime)
		{
			switch (currentCase)
			{
			case 0:
				if (currentCharIndex != introText1.Length)
				{
					intro.text += introText1[currentCharIndex];
					currentCharIndex++;
					if (currentCharIndex == introText1.Length)
					{
						currentCase += 1;
						currentCharIndex = 0;
						UpdateNextTime(0.5f);
					}
					UpdateNextTime(transitionTime);
				}
				break;
			case 1:
				intro.text += "\n\n";
				UpdateNextTime(0.5f);
				currentCase += 1;
				break;
			case 2:
				if (currentCharIndex != introText2.Length)
				{
					intro.text += introText2[currentCharIndex];
					currentCharIndex++;
					if (currentCharIndex == introText2.Length)
					{
						currentCase += 1;
						currentCharIndex = 0;
						UpdateNextTime(transitionTime * 5);
					}
					UpdateNextTime(transitionTime * 3);
				}
				break;
			case 3:
				if (currentCharIndex != introText3.Length)
				{
					intro.text += introText3[currentCharIndex];
					currentCharIndex++;
					if (currentCharIndex == introText3.Length)
					{
						currentCase += 1;
						currentCharIndex = 0;
						intro.text += "\n\n\n";
                        audio.PlayOneShot(PhilTalk);
						UpdateNextTime(transitionTime * 5);
					}
					UpdateNextTime(transitionTime * 8);
				}
				break;
			case 4:
				if (currentCharIndex != introText4.Length)
				{
					intro.text += introText4[currentCharIndex];
					currentCharIndex++;
					if (currentCharIndex == introText4.Length)
					{
						currentCase += 1;
						currentCharIndex = 0;
						UpdateNextTime(transitionTime * 30);
					}
					UpdateNextTime(transitionTime * 2);
				}
				break;
			case 5:
				Application.LoadLevel (nextLevel);
				break;
			}
		}
	}

	void UpdateNextTime(float time)
	{
		nextTime = Time.time + time;
	}
}
