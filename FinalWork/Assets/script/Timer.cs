using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    private bool isRunning;

    void Start()
    {
        // 在开始游戏时启动计时器
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            // 更新经过的时间
            elapsedTime = Time.time - startTime;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish"))
        {
            StopTimer();
        }
    }
}
