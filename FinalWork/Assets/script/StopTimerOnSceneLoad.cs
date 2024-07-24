using UnityEngine;

public class StopTimerOnSceneLoad : MonoBehaviour
{
    void Start()
    {
        // 确保计时器继续运行
        if (TimerManager.Instance == null)
        {
            Debug.LogError("TimerManager is missing in the scene!");
            return;
        }

        // 停止计时器
        TimerManager.Instance.StopTimer();
        Debug.Log("Timer stopped on scene load");
    }
}
