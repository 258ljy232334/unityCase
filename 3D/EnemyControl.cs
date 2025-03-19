using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private int id = 101;
    private int hp = 100;
    private int attack = 20;
    private Vector3 position;
    private PlayerControl player;
    private Animator anim;
    private float timer = 1;
    private bool isAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent
            <PlayerControl>();
        position = transform.position;
        Destroy(gameObject, 60f);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Health <= 0 || hp <= 0)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isAttack", false);
            return;
        }
        Purse();

    }
    private void Purse()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis > 9f)
        {
            if (Vector3.Distance(transform.position, position) > 2f)
            {
                transform.LookAt(new Vector3(position.x, transform
                    .position.y, position.z));
                anim.SetBool("isRun", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isRun", false);
            }
        }
        else if (dis > 3f)
        {
            transform.LookAt(new Vector3(player.transform.position.x,
                transform.position.y, player.transform.position.z));
            transform.Translate(Vector3.forward * 4 * Time.deltaTime);
            anim.SetBool("isRun", true);
            isAttack = false;
            anim.SetBool("isAttack", false);
        }
        else
        {
            anim.SetBool("isRun", false);
            transform.LookAt(new Vector3(player.transform.position.x,
               transform.position.y, player.transform.position.z));
            anim.SetBool("isAttack", true);
            if (isAttack == false)
            { 
            isAttack=true;
                timer = 0;
            }
            timer += Time.deltaTime;
            if (timer >= 1.8f)
            {
                timer = 0;
                player.GetDamage(attack);
            }
        }
    }
    public void GetDamage(int damage)
    {
        GetComponentInChildren<HPManager>().ShowText("-" + damage);
        hp -= damage;
        if (hp <= 0)
        {
            anim.SetTrigger("Die");
            QuestManager.Instance.AddEnemy(id);
            Destroy(gameObject, 1f);
        }
    
    }
}
