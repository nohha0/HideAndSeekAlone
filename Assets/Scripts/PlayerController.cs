using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    CharacterStats stats;
    
    float walkSpeed = 10.0f;
    float jumpForce = 10.0f;
    public int jumpCount = 0;
    public bool isLongJump = false;
    
    public bool hasAttacked = false;
  
    
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        stats = this.gameObject.GetComponent<CharacterStats>();
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
            stats.TakeDamage();
            hasAttacked = true;
            Invoke("attackOn", 3);
            Debug.Log("목숨 -1");
        }
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
}
