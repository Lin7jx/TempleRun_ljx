using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBackground : MonoBehaviour
{
    public Canvas index;
    public Canvas background;

    public void SwitchToBackground()
    {
        background.gameObject.SetActive(true);
        index.gameObject.SetActive(false);
    }
}
