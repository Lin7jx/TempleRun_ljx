using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapScript : MonoBehaviour
{
    public Transform targetPlayer;
    // �߶�
    //�����λ��,�������Player֮��ľ���
    public float distanceUp = 2.3f;
    private Transform m_cameraTransform;
    //ͨ��Awake�õ���������G Unity ��Ϣ10 ������
    void Awake(){
        m_cameraTransform = transform;
    }
    
    //����������صķŵ�FixedUpdate��
    //LateUpdate���Ա��⿨��G Unity ��Ϣ10 ������
    void LateUpdate()
    {
        //���Ŀ��Ϊ��,����
        if (targetPlayer == null) return;
        //�����������Ŀ�����꣬Vector3.up--Vector3(0,1,0)
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
