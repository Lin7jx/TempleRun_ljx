using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class capsuleEnemyBehavior : MonoBehaviour
{
    public GameObject enemy;
    private NavMeshAgent agent;
    private Transform player;
    private bool isChasing;
   // public Slider HP;
    

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject; // ��ȡ��ǰ��Ϸ����
        
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        isChasing = true;
        //HP = GameObject.Find("Slider").GetComponent<Slider>();
      //  HP.value = 1;
    }

  //  public void reduHP(float redu)
   // {
   //     HP.value -= redu;
   // }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            
            agent.destination = player.transform.position;

        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            isChasing = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            isChasing = false;
            agent.destination = transform.position;
            UnityEngine.Debug.Log("ֹͣ׷��");
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            UnityEngine.Debug.Log("�������������");
            // �������������������߼���������Ϸ�����ȵ�
            isChasing = false;
            
            agent.destination = transform.position;
            UnityEngine.Debug.Log("ֹͣ׷��");
            Destroy(gameObject);
            //reduHP(0.05f);
        }
        
    }

   


}