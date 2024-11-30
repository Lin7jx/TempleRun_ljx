using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSE : MonoBehaviour
{
    public AudioSource aus;
    // Update is called once per frame
    void Update()
    {
        if (Globals.isPaused)
        {
            aus.Stop();
        }
        else aus.Play();
    }
}
