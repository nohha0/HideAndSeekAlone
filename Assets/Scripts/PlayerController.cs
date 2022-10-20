using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    CharacterStats stats;
    Animator animator;
    
    float walkSpeed = 500.0f;
    float jumpForce = 500.0f;
    public int jumpCount = 0;
    public bool isLongJump = false;
    
    public bool hasAttacked = false;   //피격 중복 금지
  
    
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        stats = this.gameObject.GetComponent<CharacterStats>();
        animator = GetComponent<Animator>();  
    }

    void Update()
    {
        //캐릭터 이동/점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            Jump();
            animator.SetBool("jump", true);
        }

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
        
    }

    //Rigidbody(물리연산)를 이용할 때는 FixedUpdate에 작성
    private void FixedUpdate()
    {
        if (isLongJump && rigid.velocity.y>0)   
            rigid.gravityScale = 2.0f;
        else
            rigid.gravityScale = 4.0f;

        //점프가 끝날때
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down * 1.5f, 1.5f, 
            LayerMask.GetMask("ground")); //그라운드 레이어만 체크
        if(rayHit.collider !=null) //콜라이더가 닿은게 있음
        {
            if(rayHit.distance <0.96)
            {
                Debug.Log("착지함 jump false");
                animator.SetBool("jump", false);
            }
        }

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
            stats.TakeDamage();
            hasAttacked = true;
            Invoke("attackOn", 3);
            Debug.Log("목숨 -1");
        }
    }

    //점프
    public void Jump()
    {
        rigid.AddForce(new Vector2(0.0f, jumpForce));
        jumpCount++;
        
    }

    public void attackOn()
    {
        hasAttacked = false;
    }
    //애니메이션 전환
    void RunAniCon()
    {
        if(Mathf.Abs(rigid.velocity.x)<0.4)
        {
            animator.SetBool("run", false);
        }
        else
            animator.SetBool("run", true);
    }
    

    
}
