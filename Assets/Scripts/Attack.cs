using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CharacterStats
{

    PlayerController Playstats;
    Animator animator;
    float curTime;

    //콜라이더 위치 
    public Transform pos;
    public Vector2 boxSize;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C)&&curTime <=0) // 공격 애니메이션
        {

            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D item in collider2Ds)
            {
                Debug.Log("공격");
            }

            animator.SetTrigger("attack");
            curTime = attackSpeed;
            
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    //콜라이더 확인 그림
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

}
