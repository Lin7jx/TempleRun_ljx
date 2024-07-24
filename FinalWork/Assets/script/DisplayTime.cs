using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public Text timeText; // 用来显示时间的 UI Text 组件
    private Timer timer; // 对计时器脚本的引用

    void Start()
    {
        // 查找并获取计时器脚本的引用
        timer = FindObjectOfType<Timer>();

        // 确保在当前场景的 Canvas 中设置了要显示时间的 Text 组件
        if (timeText == null)
        {
            Debug.LogError("Time Text component is not assigned!");
        }
    }

    void Update()
    {
        // 更新显示的时间
        if (timer != null)
        {
            float elapsedTime = timer.GetElapsedTime();
            timeText.text = FormatTime(elapsedTime);
        }
    }

    // 格式化时间为分钟:秒钟
    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("耗时："+"{0:00}:{1:00}", minutes, seconds);
    }
}
