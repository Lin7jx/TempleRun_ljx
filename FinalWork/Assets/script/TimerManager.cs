using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{

    public static TimerManager Instance { get; private set; }
    private float startTime;
    private bool isRunning;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            // 可以在这里更新计时器相关的其他逻辑
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

    public void ResetTimer()
    {
        startTime = Time.time;
        isRunning = false;
    }

    public float GetElapsedTime()
    {
        return isRunning ? Time.time - startTime : Time.time - startTime;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopTimer(); // 场景加载完成后停止计时器
    }


}
