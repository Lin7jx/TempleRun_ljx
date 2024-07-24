using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToIndex : MonoBehaviour
{
    public Canvas index;
    public Canvas background;

    public void SwitchToIndex()
    {
        index.gameObject.SetActive(true);
        background.gameObject.SetActive(false);
    }
}
