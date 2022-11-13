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

    public GameObject AttackBox;  //���� ����Ʈ, ����Ʈ ��������Ʈ�� ��������

    //�ݶ��̴� ��ġ 
    public Transform Rpos;
    public Transform Lpos;
    public Vector2 boxSize;
    SpriteRenderer rend;  //�÷��̾� ��������Ʈ


    //������ �¿���� ����
    public bool AttackLeftOn = true;
    public bool AttackRightOn = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && curTime <=0) // ���ݹ�ư�� �����ٸ�
        {

            if (rend.flipX)  //������ �ü�
            {
                //�����Ҷ����� attackSpeed��ŭ �¿���ȯ ����
                AttackLeftOn = false;  //���� �ü� ����
                Invoke("NotMove", 0.4f);  //0.4�ʵ� ����
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Rpos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    //���� ����Ʈ ��ȯ
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
                AttackRightOn = false;  //���� �ü� ����
                Invoke("NotMove", 0.4f);  //0.4�ʵ� ����
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Lpos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    //���� ����Ʈ ��ȯ
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
        else //������ �ʴ´ٸ� �ð� ����
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

    // ��ȯ���� �޼ҵ�
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
