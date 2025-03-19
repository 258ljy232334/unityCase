using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private string Name = "����";
    private string Content = "���Ǹ��еľ�����,�������ᱲչ¶���Ĺ��" +
        ",��ɱ��Ϊ��һ����ʯͷ�˰�";
    private Transform player;
    private int Questid = 1001;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 4f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIManager.Instance.Show(Name,Content,Questid);
            }
        }
        
    }
}
