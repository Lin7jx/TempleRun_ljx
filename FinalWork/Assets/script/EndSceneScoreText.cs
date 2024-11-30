using UnityEngine;
using UnityEngine.UI;
using static Globals;
public class EndSceneScoreText : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        scoreText.text = string.Format("最终分数：{0}\n{1}", score, time);
    }
}