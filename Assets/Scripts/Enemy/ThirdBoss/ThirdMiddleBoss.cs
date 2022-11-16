using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdMiddleBoss : Enemy
{


    //������ ��ų ���������� ��
    List<string> SetSkill = new List<string> { "Knife", "Forward", "Summon", "Telepo" };
    public int Knife_Pattern;     //������ ����, ���� ����


    //���� ��ȯ������ 
    [SerializeField] GameObject Nomal_1;
    [SerializeField] GameObject Nomal_2;
    [SerializeField] GameObject Fly_1;
    [SerializeField] GameObject Fly_2;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject MagicCircle;

    //��ȯ��ġ�� ���ϱ� ���� pos
<<<<<<< Updated upstream
    [SerializeField] Transform pos;



    int CurrentPos;         //�ߺ����� ����ġ�� �˷���

    //Skill : 0 = Į �����⽺ų, 1 = ����, 2 = ��ȯ, 3 = ����  
    int BeforeSkill;        //�ߺ��� �Ǹ� �ȵǴ� ��ų�� �ֱ� ������ �װ� �Ǵ��ϴ� ����
    int SetSkill;           //������ ��ų ���������� ��
    Transform SummonPos;    //���� ��ȯ�� �������� �ϴ� ����
    SpriteRenderer rend;    //�ߺ��� 

    //���� Speed


=======
    [SerializeField] Transform BossPos;
    [SerializeField] Transform PlayerPos;
    [SerializeField] Transform BasePos;

    //Skill : 0 = Į �����⽺ų, 1 = ����, 2 = ��ȯ, 3 = ����        
    Transform SummonPos;        //���� ��ȯ�� �������� �ϴ� ����
    public SpriteRenderer rend;
    Rigidbody2D riged;

    float ForWardTime = 0;      //���� �����ϴ� �ð�
    int CurrentPos;             //�ߺ����� ����ġ�� �˷���
    int BeforeSkill;            //�ߺ��� �Ǹ� �ȵǴ� ��ų�� �ֱ� ������ �װ� �Ǵ��ϴ� ���� 
    int SetSkillNum;
    float ForwardSpeed = 180;    //���� ���ǵ�  
    float Difficulty = 6f;           //��ȯ �ӵ�, ���̵�
    bool cooltime = false;
    bool telepo = false;
    Vector3 pos;                //�ʱ�ȭ ����

    float Summoncurtime;
    float Summoncooltime = 20;
>>>>>>> Stashed changes

    override protected void Start()
    {
        base.Start();
        rend = GetComponent<SpriteRenderer>();
        riged = GetComponent<Rigidbody2D>();


        Invoke("ReTelepo", 2); //�߾ӿ��ִ� ������ ������ ��ġ ���
        //SetSkillNum = Random.Range(0, 4);   //ó�� �� ��ų ����
        Invoke("cooltrue", Difficulty);
        SetSkillNum = 0;

    }

    override protected void Update()
    {
        base.Update();


        if(telepo)  //���� ��ġ ������
        {
            telepo = false;
            ReTelepo();
            SetSkillNum = Random.Range(0, 4);
        }
        if(cooltime)
        {
            switch (SetSkill[SetSkillNum])
            {
                case "Knife":       //������
                    if (BeforeSkill == 0)
                    {
                        SetSkillNum = Random.Range(0, 4);
                        break;
                    }
                    KnifeSkill();
                    break;
                case "Forward":     //����
                    if (BeforeSkill == 1)
                    {
                        SetSkillNum = Random.Range(0, 4);
                        break;
                    }
                    ForwardSKill();
                    break;
                case "Summon":      //��ȯ
                    if (BeforeSkill == 2)
                    {
                        SetSkillNum = Random.Range(0, 4);
                        break;
                    }
                    SummonSkill();
                    break;
                case "Telepo":      //����
                    if (BeforeSkill == 3)
                    {
                        SetSkillNum = Random.Range(0, 4);
                        break;
                    }
                    Teleport();
                    break;
            }
        }
        Summoncurtime -= Time.deltaTime;   //��ȯ��ų ����� 30�� ���� 0�̵Ǹ� �ٽ� ��ȯ

    }

    //��ų


    //--------------------------------------------------------------------


    //���� ��ȯ��ų
    void SummonSkill()
    {
        Debug.Log("��ȯ");
        if (CurrentPos == 2)   //�ߺ��� ��ġ�� �߾��̶��
        {
            //�⺻3, ���� 3 ��ȯ

            
            Debug.Log("�̳� ��ȯ");
            for (int i = 0; i < 3; i++)
            {
                SummonSetPos();
                Instantiate(MagicCircle, pos, transform.rotation);                
                Instantiate(Nomal_2, pos, transform.rotation);

            }
            for (int i = 0; i < 3; i++)
            {

                SummonSetPos();
                Instantiate(MagicCircle, pos, transform.rotation);
                Instantiate(Fly_2, pos, transform.rotation);

            }
        }
        if (Summoncurtime <= 0)
        {
            Summoncurtime = Summoncooltime;
            int SetMoster;
            
            if(CurrentPos != 2)
            {
                SetMoster = Random.Range(0, 2);
                if (SetMoster == 0)
                {
                    //�⺻ 4
                    Debug.Log("�⺻ ��ȯ");
                    for (int i = 0; i < 2; i++)
                    {

                        SummonSetPos();
                        Instantiate(MagicCircle, pos, transform.rotation);
                        Instantiate(Nomal_1, pos, transform.rotation);

                    }
                    for (int i = 0; i < 2; i++)
                    {

                        SummonSetPos();
                        Instantiate(MagicCircle, pos, transform.rotation);
                        Instantiate(Nomal_2, pos, transform.rotation);

                    }
                }
                if (SetMoster == 1)
                {
                    //���� 4
                    Debug.Log("���� ��ȯ");
                    for (int i = 0; i < 2; i++)
                    {

                        SummonSetPos();
                        Instantiate(Fly_1, pos, transform.rotation);

                    }
                    for (int i = 0; i < 2; i++)
                    {

                        SummonSetPos();
                        Instantiate(Fly_2, pos, transform.rotation);

                    }
                }
            }
        
        }
        cooltime = false;
        Invoke("cooltrue", Difficulty);
        BeforeSkill = 2; //��ȯ����Ϸ�
        SetSkillNum = Random.Range(0, 4);  //���ο� ��ų

    }

    //���� ���� ��ų
    void ForwardSKill()
    {

        if (ForWardTime < 2f)
        {
<<<<<<< Updated upstream
            if(rend.flipX) //������ ����
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            if(!rend.flipX) //���� ����
            {
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
            }

=======
            if(rend.flipX)
            {
                transform.Translate(transform.right * ForwardSpeed * Time.deltaTime);
            }
            if (!rend.flipX)
            {
                transform.Translate(transform.right * -1 * ForwardSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.Log("����");
            riged.velocity = Vector2.zero;   //���� ����
            ForWardTime = 0;  //�ٽ� 0           
            telepo = true;
>>>>>>> Stashed changes

        }
        ForWardTime += Time.deltaTime;  //�ð�����
    }

    void KnifeSkill()
    {
<<<<<<< Updated upstream
        // �����Լ�  | b = 2
        // ��ȯ �밢 ������ �밢 �Ʒ���

        //�밢 �Ʒ����� �밢 ����

        //��������

=======
        Debug.Log("������");
        Knife_Pattern = Random.Range(1, 4);
        switch(Knife_Pattern)
        {
            case 1:
                Instantiate(Knife, BossPos);  //����
                break;
            case 2:
                Instantiate(Knife, BossPos);  //�밢 ��
                break;
            case 3:
                Vector3 down = new Vector3(BossPos.position.x, BossPos.position.y, 1);
                Instantiate(Knife, down,transform.rotation);  //�밢�Ʒ�
                break;
        }
        cooltime = false;
        Invoke("cooltrue", Difficulty);
        BeforeSkill = 0; //����������Ϸ�
        SetSkillNum = Random.Range(0, 4);
>>>>>>> Stashed changes
    }
    void Teleport()
    {
        Debug.Log("����");
        SetSkillNum = 3;  //������ ����
        if (BeforeSkill != 3) 
        {
            int a;
            a = CurrentPos;
            CurrentPos = Random.Range(0, 3);   //���� ��ġ ���ϴ� �Լ�
            if (CurrentPos == 2)   //�߾ӿ� ������ �ȴٸ�
            {
                //�߾����� �̵��ϴ� �޼ҵ� �ۼ�
                transform.position = new Vector2(BasePos.position.x, BasePos.position.y + 50);
                Invoke("SummonSkill", 2);

                //�ٽ� �߾ӿܿ� ����
                Invoke("ReTelepo", 2.5f);  //1�ʵ� �ٽ� ����
            }
            else if (CurrentPos == 0)
            {
                
                if (a == 0)
                {
                    //����������
                    transform.position = new Vector2(BasePos.position.x + 80, BasePos.position.y);
                    rend.flipX = false;
                }
                else
                {
                    //��������
                    transform.position = new Vector2(BasePos.position.x - 80, BasePos.position.y);
                    rend.flipX = true;
                }
            }
            else
            {
                if(a == 1)
                {
                    //��������
                    transform.position = new Vector2(BasePos.position.x - 80, BasePos.position.y);
                    rend.flipX = true;
                }
                else
                {
                    //����������
                    transform.position = new Vector2(BasePos.position.x + 80, BasePos.position.y);
                    rend.flipX = false;
                }
            }

        }
        cooltime = false;
        Invoke("cooltrue", Difficulty);
        BeforeSkill = 3; //��������Ϸ�
        SetSkillNum = Random.Range(0, 4);
    }
    //-----------------------------------------------------------------------


    //�����Լ�


    //��ȯ ��ġ ���ϴ� �Լ�
    void SummonSetPos()
    {
        if (CurrentPos == 3)  //�߾ӿ� ��ġ
        {
            int x = Random.Range(-50, 51);
            pos = new Vector3(BasePos.position.x + x, BossPos.position.y, 1);
        }
        else
        {
            int SetPosInt = Random.Range(0, 2);
            if (SetPosInt == 0)
            {
                //������ ������ ������
                int x = Random.Range(-20, 21);
                int y = Random.Range(-10, 11);
                pos = new Vector3(BossPos.position.x + x, BossPos.position.y + y, 1);
            }
            if (SetPosInt == 1)
            {
                int x = Random.Range(-40, 41);
                int y = Random.Range(-10, 11);
                pos = new Vector3(PlayerPos.position.x + x, PlayerPos.position.y + y);
            }
        }
    }

    void ReTelepo()
    {
        CurrentPos = Random.Range(0, 2);
        if (CurrentPos == 0)
        {
            transform.position = new Vector2(BasePos.position.x - 80, BasePos.position.y);
            rend.flipX = true;
        }
        else
        {
            transform.position = new Vector2(BasePos.position.x + 80, BasePos.position.y);
            rend.flipX = false;
        }
    }

    void cooltrue()
    {
        cooltime = true;
    }

}