using UnityEngine;
using UnityEngine.UI;

public class DisplayTimeInNewScene : MonoBehaviour
{
    public Text timeText;
    bool flag = true;

    void Start()
    {
        // 确保计时器继续运行
        if (TimerManager.Instance == null)
        {
            Debug.LogError("TimerManager is missing in the scene!");
            return;
        }
        TimerManager.Instance.StopTimer();
    }

    void Update()
    {
        
        if (TimerManager.Instance != null & flag)
        {
            float elapsedTime = TimerManager.Instance.GetElapsedTime();
            timeText.text = FormatTime(elapsedTime);
            flag = false;
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("耗时：{0:00}:{1:00}", minutes, seconds);
    }
}
