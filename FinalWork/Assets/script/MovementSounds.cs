using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSounds : MonoBehaviour
{
    public AudioClip runningClip; // 奔跑音效的音频剪辑
    public float runningVolume = 0.5f; // 音量大小
    private AudioSource audioSource; // 用来播放音效的音频源组件
    private bool isRunning = false; // 角色是否正在奔跑

    void Start()
    {
        // 添加音频源组件
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = runningClip;
        audioSource.volume = runningVolume;
        audioSource.loop = true; // 设置为循环播放
    }

    void Update()
    {
        // 假设通过输入检测角色是否正在奔跑
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        // 如果角色正在奔跑且音效未播放，则播放音效
        if (isMoving && !isRunning)
        {
            isRunning = true;
            audioSource.Play();
        }
        // 如果角色停止奔跑，则停止音效
        else if (!isMoving && isRunning)
        {
            isRunning = false;
            audioSource.Stop();
        }

        
    }
}
