using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private string Name = "村民";
    private string Content = "我那高尚的救主啊,请您向吾辈展露您的光辉" +
        ",屠杀那为祸一方的石头人吧";
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
