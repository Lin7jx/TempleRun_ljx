using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplay : MonoBehaviour
{
    public GameObject zombieGameObject; // 僵尸的游戏对象
    public GameObject playerGameObject; // 玩家的游戏对象

    public Text distanceText; // 显示距离的Text组件

    void Update()
    {
        // 获取僵尸和玩家的位置
        Vector3 zombiePosition = zombieGameObject.transform.position;
        Vector3 playerPosition = playerGameObject.transform.position;

        // 计算距离
        float distance = Vector3.Distance(zombiePosition, playerPosition);
        // 更新UI显示
        distanceText.text = $"僵尸距离: "+distance.ToString("F2");
    }
}
