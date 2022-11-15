using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdMiddleBoss : Enemy
{
    //���� ��ȯ������ 

    [SerializeField] GameObject Nomal_1;
    [SerializeField] GameObject Nomal_2;
    [SerializeField] GameObject Fly_1;
    [SerializeField] GameObject Fly_2;

    //��ȯ��ġ�� ���ϱ� ���� pos
    [SerializeField] Transform pos;



    int CurrentPos;         //�ߺ����� ����ġ�� �˷���

    //Skill : 0 = Į �����⽺ų, 1 = ����, 2 = ��ȯ, 3 = ����  
    int BeforeSkill;        //�ߺ��� �Ǹ� �ȵǴ� ��ų�� �ֱ� ������ �װ� �Ǵ��ϴ� ����
    int SetSkill;           //������ ��ų ���������� ��
    Transform SummonPos;    //���� ��ȯ�� �������� �ϴ� ����
    SpriteRenderer rend;    //�ߺ��� 

    //���� Speed



    override protected void Start()
    {
        base.Start();

        Teleport(); //�߾ӿ��ִ� ������ ������ ��ġ ���
        SetSkill = Random.Range(0, 3);   //ó�� �� ��ų ����

    }

    override protected void Update()
    {
        base.Update();



        if (SetSkill == 0)
        {
            KnifeSkill();
        }


    }

    //��ų
    //--------------------------------------------------------------------
    //���� ��ȯ��ų
    void SummonSkill()
    {
        int SetMoster;
        if (CurrentPos == 2)   //�ߺ��� ��ġ�� �߾��̶��
        {
            //�⺻3, ���� 3 ��ȯ
        }
        else
        {
            SetMoster = Random.Range(0, 1);
            if (SetMoster == 0)
            {
                //�⺻ 4
            }
            if (SetMoster == 1)
            {
                //���� 4
            }
        }
        BeforeSkill = 2; //��ȯ����Ϸ�
        SetSkill = Random.Range(0, 3);  //���ο� ��ų

    }

    //���� ���� ��ų
    void ForwardSKill()
    {
        float ForWardTime = 0;  //���� �����ϴ� �ð�

        if (ForWardTime < 1f)
        {
            if(rend.flipX) //������ ����
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            if(!rend.flipX) //���� ����
            {
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
            }


        }
        ForWardTime += Time.deltaTime;  //�ð�����


        Teleport();   //�����ϸ� ������ ������ ��ġ ������
        BeforeSkill = 1; //��������Ϸ�
        SetSkill = Random.Range(0, 3);
    }

    //��Į ������ ��ų : �� �Լ������� �������� ��ȯ�� �Ѵ�.
    void KnifeSkill()
    {
        // �����Լ�  | b = 2
        // ��ȯ �밢 ������ �밢 �Ʒ���

        //�밢 �Ʒ����� �밢 ����

        //��������

    }
    void Teleport()
    {
        if (BeforeSkill != 3)    //���� ��뽺ų�� ������ �ƴҰ�� ����
        {
            CurrentPos = Random.Range(0, 2);   //���� ��ġ ���ϴ� �Լ�
            if (CurrentPos == 2)   //�߾ӿ� ������ �ȴٸ�
            {
                //�߾����� �̵��ϴ� �޼ҵ� �ۼ�
                SummonSkill();

                //�ٽ� �߾ӿܿ� ����
                CurrentPos = Random.Range(0, 1);
                if (CurrentPos == 0)
                {
                    //��������
                }
                else
                {
                    //����������
                }
            }
            else if (CurrentPos == 0)
            {
                //��������
            }
            else
            {
                //����������
            }

        }
        BeforeSkill = 3; //��������Ϸ�
        SetSkill = Random.Range(0, 3);
    }
    //-----------------------------------------------------------------------


    //�����Լ�


    //��ȯ ��ġ ���ϴ� �Լ�
    void SummonSetPos()
    {
        if (CurrentPos == 3)  //�߾ӿ� ��ġ
        {
            //�⺻ 3, ���� 3 ���� ������  ������ 6�� ����
        }
        else
        {
            int SetPos = Random.Range(0, 1);
            if (SetPos == 0)
            {
                //������ ������ ������
            }
            if (SetPos == 0)
            {
                //�÷��̾ ������ ������
            }
        }
    }




    //���� ���� ��ġ |  b = 2
    // 0 = ����, 1 = ������, 2 = �߾�

    //��ȯ�Ǵ� ���ʹ� ���� |   b = 1 
    //0 = �⺻ 4, 1 = ���� 4
    //if ������ �߾ӿ� ������� �⺻ 3, ���� 3

    //if ������ ����, Ȥ�� �����ʿ� �������  | b = 3
    //0 = Į �����⽺ų, 1 = ����, 2 = ����,  3 = ��ȯ
}