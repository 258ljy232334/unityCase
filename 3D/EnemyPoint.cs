using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    private int count = 3;
    private float timer = 0;
   

    void Update()
    {
        Create();
    }
    private void Create()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            int n = transform.childCount;
           
            if (n < count)
            {
                Vector3 square = transform.position;
                square.x+=Random.Range(-10,10);
                square.z+=Random.Range(-10,10);
                Quaternion quaternion = Quaternion.Euler
                    (0,Random.Range(0, 360), 0);
                GameObject enemy=Instantiate(Enemy,square,quaternion);
                enemy.transform.SetParent(transform);
            }


        }
    
    }
}
