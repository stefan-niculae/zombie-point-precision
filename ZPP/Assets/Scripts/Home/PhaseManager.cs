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


    void Update()
    {
        // Check if not all the colors have grown
        if (Time.timeSinceLevelLoad > 0 && Utils.Instance.FloatEqual(Time.timeSinceLevelLoad % interval, 0) && currentIndex < colorBGs.Length)
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
