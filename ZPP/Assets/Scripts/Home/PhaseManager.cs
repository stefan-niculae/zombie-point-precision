using UnityEngine;

public class PhaseManager : Singleton<PhaseManager>
{
    [SerializeField]
    ColorBG[] colorBGs;

    int currentIndex = 0;

    void Update()
    {
		// Check if not all the colors have grown
        if (Input.GetKeyDown(KeyCode.N) && currentIndex < colorBGs.Length)
        {
            colorBGs[currentIndex].StartGrow();
            currentIndex++;
        }
    }

    public void EndGame(string game, bool logEnd = false)
    {
        if (logEnd)
            print("game over from " + game + "!");
    }
}
