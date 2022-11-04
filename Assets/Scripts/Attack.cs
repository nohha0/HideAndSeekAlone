using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CharacterStats
{
    PlayerController Playstats;
    Animator animator;
    float curTime;
    bool fireRangeOn = false;
    public GameObject rangeObject;
    GameObject range_object;

    //�ݶ��̴� ��ġ 
    public Transform pos;
    public Vector2 boxSize;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&&curTime <=0) // ���� �ִϸ��̼�
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if(collider.tag =="Enemy")
                {
                    collider.GetComponent<Enemy>().TakeDamage(attackPower);
                }
            }
            animator.SetTrigger("attack");
            curTime = attackSpeed;
        }
        else
        {
            curTime -= Time.deltaTime;
        }

        //--------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.V)&&!fireRangeOn)
        {
            fireRangeOn = true;
            Vector2 playerPos = new Vector2(transform.position.x, -42f);
            range_object = Instantiate(rangeObject, playerPos, transform.rotation);
            Invoke("fireRangeOff", 3);
        }
    }

    
    //--------------------------------------------------------------------------

    //�ݶ��̴� Ȯ�� �׸�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    public void fireRangeOff()
    {
        fireRangeOn = false;
        Destroy(range_object);
    }
}
