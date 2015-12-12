using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text Display;
    float startTime;
	int timeSinceStart
	{
		get
		{
            return int.Parse(Display.text);
        }
		set
		{
            Display.text = value.ToString();
        }
	}

    void Awake()
	{
        Display = GetComponent<Text>();
    }

	void Start()
	{
        startTime = Time.time;
    }

	void Update()
	{
        timeSinceStart = (int)(Time.time - startTime);
    }
}
