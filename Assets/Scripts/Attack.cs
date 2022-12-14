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

    public GameObject AttackBox;  //어택 이팩트, 이팩트 스프라이트는 수정예정

    //콜라이더 위치 
    public Transform Rpos;
    public Transform Lpos;
    public Vector2 boxSize;
    SpriteRenderer rend;  //플레이어 스프라이트


    //공격중 좌우반전 금지
    public bool AttackLeftOn = true;
    public bool AttackRightOn = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && curTime <=0) // 공격버튼을 눌렀다면
        {

            if (rend.flipX)  //오른쪽 시선
            {
                //공격할때마다 attackSpeed만큼 좌우전환 금지
                AttackLeftOn = false;  //왼쪽 시선 금지
                Invoke("NotMove", 0.4f);  //0.4초뒤 해제
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Rpos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    //공격 이팩트 소환
                    Instantiate(AttackBox, Rpos.position, transform.rotation);


                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy>().TakeDamage(attackPower);
                    }
                }
                animator.SetTrigger("attack");
                curTime = attackSpeed;
            }
            else if(!rend.flipX)
            {
                AttackRightOn = false;  //왼쪽 시선 금지
                Invoke("NotMove", 0.4f);  //0.4초뒤 해제
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Lpos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    //공격 이팩트 소환
                    Instantiate(AttackBox, Lpos.position, transform.rotation);

                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy>().TakeDamage(attackPower);
                    }
                }
                animator.SetTrigger("attack");
                curTime = attackSpeed;
            }
        }
        else //누르지 않는다면 시간 단축
        {
            curTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.V) && !fireRangeOn)
        {
            fireRangeOn = true;
            Vector2 playerPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
            range_object = Instantiate(rangeObject, playerPos, transform.rotation);
            Invoke("fireRangeOff", 3);
        }
    }

    
    //--------------------------------------------------------------------------

    // 전환금지 메소드
    void NotMove()
    {
        AttackLeftOn = true;
        AttackRightOn = true;
    }


    public void fireRangeOff()
    {
        fireRangeOn = false;
        Destroy(range_object);
    }
}
