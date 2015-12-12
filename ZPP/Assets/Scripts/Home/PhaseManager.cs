using UnityEngine;

public class PhaseManager : Singleton<PhaseManager>
{
    [SerializeField]
    ColorBG[] colorBGs;
    [SerializeField]
    GameObject[] toEnable2, toEnable3, toEnable4;
    [SerializeField]
    float interval;

    int currentIndex = 0;

    bool passed1, passed2, passed3;


    void Update()
    {
        // Check if not all the colors have grown
        // if (Time.timeSinceLevelLoad > 0 && Mathf.Abs(Time.timeSinceLevelLoad % interval) < .01 && currentIndex < colorBGs.Length)
        float f = Time.timeSinceLevelLoad;
        if ((f > 1 * interval && !passed1) || (f > 2 * interval && !passed2) || (f > 3 * interval && !passed3))
        {
            // fkin 14 mins left, had to hardcode!
            if (currentIndex == 0)
                EnableObjs(toEnable2);
            if (currentIndex == 1)
                EnableObjs(toEnable3);
            if (currentIndex == 2)
                EnableObjs(toEnable4);

            colorBGs[currentIndex].StartGrow();
            currentIndex++;

            if ((f > 1 * interval && !passed1))
                passed1 = true;

            if ((f > 2 * interval && !passed2))
                passed2 = true;

            if ((f > 3 * interval && !passed3))
                passed3 = true;
        }
    }

    void EnableObjs(GameObject[] objs)
    {
        foreach (var obj in objs)
            obj.SetActive(true);
    }

    public void EndGame (string game, bool logEnd = false)
    {
        // Time.timeScale = 0;
        if (logEnd)
            print("game over from " + game + "!");
        References.Instance.gameOverReason.text = game;
    }
}
