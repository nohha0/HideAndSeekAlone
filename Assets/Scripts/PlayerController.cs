using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    
    float walkSpeed = 10.0f;
    float jumpForce = 500.0f;
    public int jumpCount = 0;
    public bool isLongJump = false;
    public bool TimeStop = false;
    
    public bool hasAttacked = false;
    public int HP = 4;
    public int Level = 1;
    public int levelCount= 0;
    public int expCurrent = 0;      //�������ġ
    public int expLeft = 1000;      //����. �������� �ʿ��� ����ġ

    int expBase = 1000;      //���. ����1�淹��2 �ʿ��� ����ġ
    float expMod = 1.21f;    //����ġ ������ (����)

    public int attackPower = 20;    //���ݷ� 
    public double attackSpeed;      //���ݼӵ�
    public float attackRange;       //���ݹ���
    public int avoidanceRate = 0;   //ȸ����


    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //ĳ���� �̵�/����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
            Jump();

        if (Input.GetKey(KeyCode.Space))
            isLongJump = true;

        if (Input.GetKeyUp(KeyCode.Space))
            isLongJump = false;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = false;
            Vector2 vec = transform.position;
            vec += new Vector2(-walkSpeed * Time.deltaTime, 0.0f);
            transform.position = vec;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
            Vector2 vec = transform.position;
            vec += new Vector2(walkSpeed * Time.deltaTime, 0.0f);
            transform.position = vec;
        }

        //ĳ���� �⺻����
        if (Input.GetKeyDown(KeyCode.X))
        {
            //�߰�)if �÷��̾��� ���� �ݶ��̴��� ���ʹ��� �ݶ��̴��� �ε�����
            GainExp(500);
            Debug.Log("����ġ 500 ȹ��");
        }

        if (expCurrent >= expLeft)
        {
            LevelUp();
        }

        if (levelCount > 0)
        {
            while (levelCount > 0)
            {
                Enhance();
                levelCount--;
            }
        }

        if (Time.timeScale==0 && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            TimeStop = false;
        }
    }

    //Rigidbody(��������)�� �̿��� ���� FixedUpdate�� �ۼ�
    private void FixedUpdate()
    {
        if (isLongJump && rigid.velocity.y>0)   
            rigid.gravityScale = 2.0f;
        else
            rigid.gravityScale = 4.0f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("�浹");
            this.jumpCount = 0;
        }
        if (other.gameObject.CompareTag("Enemy")&&!hasAttacked)
        {
            this.HP--;
            hasAttacked = true;
            Invoke("attackOn", 3);
            Debug.Log("��� -1");
        }
    }

    virtual public void Enhance()
    {
        Time.timeScale = 0;
        TimeStop = true;
        Debug.Log("��ȭ");
    }

    public void Jump()
    {
        rigid.AddForce(new Vector2(0.0f, jumpForce));
        jumpCount++;
    }

    public void attackOn()
    {
        hasAttacked = false;
    }

    public void GainExp(int e)
    {
        expCurrent += e;
    }

    public void LevelUp()
    {
        expCurrent -= expLeft;  //������ �� �ʰ��ߴ� ����ġ�� ���ư��� ����
        Level++;
        levelCount++;

        float t = Mathf.Pow(expMod, Level);         //Pow : expMod^Level
        expLeft = (int)Mathf.Floor(expBase * t);    //Floor : �Ҽ��� ����
        Debug.Log(Level + "������ ������!");
        

        //1.2 = 1000, 1440, 1728 ... 12839, 15407, 18488
        //1.21 = 1000, 1464, 1771 ... 14420, 17449, 21113
    }

    
}
