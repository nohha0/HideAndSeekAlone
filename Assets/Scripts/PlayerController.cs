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
    public int expCurrent = 0;      //현재경험치
    public int expLeft = 1000;      //변수. 레벨업에 필요한 경험치

    int expBase = 1000;      //상수. 레벨1→레벨2 필요한 경험치
    float expMod = 1.21f;    //경험치 증가량 (지수)

    public int attackPower = 20;    //공격력 
    public double attackSpeed;      //공격속도
    public float attackRange;       //공격범위
    public int avoidanceRate = 0;   //회피율


    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //캐릭터 이동/점프
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

        //캐릭터 기본공격
        if (Input.GetKeyDown(KeyCode.X))
        {
            //추가)if 플레이어의 무기 콜라이더와 에너미의 콜라이더가 부딪히면
            GainExp(500);
            Debug.Log("경험치 500 획득");
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

    //Rigidbody(물리연산)를 이용할 때는 FixedUpdate에 작성
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
            Debug.Log("충돌");
            this.jumpCount = 0;
        }
        if (other.gameObject.CompareTag("Enemy")&&!hasAttacked)
        {
            this.HP--;
            hasAttacked = true;
            Invoke("attackOn", 3);
            Debug.Log("목숨 -1");
        }
    }

    virtual public void Enhance()
    {
        Time.timeScale = 0;
        TimeStop = true;
        Debug.Log("강화");
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
        expCurrent -= expLeft;  //레벨업 시 초과했던 경험치가 날아가지 않음
        Level++;
        levelCount++;

        float t = Mathf.Pow(expMod, Level);         //Pow : expMod^Level
        expLeft = (int)Mathf.Floor(expBase * t);    //Floor : 소수값 버림
        Debug.Log(Level + "레벨로 레벨업!");
        

        //1.2 = 1000, 1440, 1728 ... 12839, 15407, 18488
        //1.21 = 1000, 1464, 1771 ... 14420, 17449, 21113
    }

    
}
