using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapScript : MonoBehaviour
{
    public Transform targetPlayer;
    // 高度
    //摄像机位置,摄像机与Player之间的距离
    public float distanceUp = 2.3f;
    private Transform m_cameraTransform;
    //通过Awake拿到自身的组件G Unity 消息10 个引用
    void Awake(){
        m_cameraTransform = transform;
    }
    
    //物理引擎相关的放到FixedUpdate中
    //LateUpdate可以避免卡顿G Unity 消息10 个引用
    void LateUpdate()
    {
        //如果目标为空,返回
        if (targetPlayer == null) return;
        //计算摄像机的目标坐标，Vector3.up--Vector3(0,1,0)
        m_cameraTransform.position = targetPlayer.position + Vector3.up * distanceUp;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
