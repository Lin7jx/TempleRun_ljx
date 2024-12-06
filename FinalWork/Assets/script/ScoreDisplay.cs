
using UnityEngine;
using UnityEngine.UI;
using static Globals;


public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText; // 用来显示时间的 UI Text 组件
    private Timer timer; // 对计时器脚本的引用

    public GameObject playerGameObject; // 玩家的游戏对象
    public GameObject zombieGameObject;
    private Vector3 startingPoint;
    private float timed = .0f;

    private float baseRate = 1;
    private float lastDistance = 0;
    private float distance = 0;
    void Start()
    {
        
        // 查找并获取计时器脚本的引用
        timer = FindObjectOfType<Timer>();
        score = 0;
        scoreText.text = "";
        startingPoint = playerGameObject.transform.position;
        if (scoreText == null)
        {
            Debug.LogError("Score Text component is not assigned!");
        }
    }

    void Update()
    {
        timed += Time.deltaTime;
        var multiplier = Vector3.Distance(zombieGameObject.transform.position, playerGameObject.transform.position) * .05f;
        distance = Vector3.Distance(startingPoint, playerGameObject.transform.position);
        baseRate += multiplier;
        if (timed > .3)
        {
            score = lastDistance == distance ? score : (int)(distance * baseRate);
            timed -= .3f;            

            if (timer != null)
            {
                scoreText.text = FormatScore(score);
            }
        }
    }

    void LateUpdate()
    {
        lastDistance = distance;
    }
    private string FormatScore(float score)
    {
        return string.Format("分数： {0}", score);
    }
}
