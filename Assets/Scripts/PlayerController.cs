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
    float jumpForce = 2000.0f;
    public int jumpCount = 0;
    public bool isLongJump = false;
    
    public bool hasAttacked = false;   //�ǰ� �ߺ� ����
  
    
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        stats = this.gameObject.GetComponent<CharacterStats>();
        animator = GetComponent<Animator>();  
    }

    void Update()
    {
        animator.SetBool("run", false);
        //ĳ���� �̵�/����
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
            animator.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
            Vector2 vec = transform.position;
            vec += new Vector2(walkSpeed * Time.deltaTime, 0.0f);
            transform.position = vec;
            animator.SetBool("run", true);
        }
        
    }

    //Rigidbody(��������)�� �̿��� ���� FixedUpdate�� �ۼ�
    private void FixedUpdate()
    {
        if (isLongJump) //rigid.velocity.y ���� ��� ������
            rigid.gravityScale = 80.0f;
        else
            rigid.gravityScale = 100.0f;


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("�浹");
            this.jumpCount = 0;
            animator.SetBool("jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !hasAttacked)
        {
            stats.TakeDamage();
            hasAttacked = true;
            Invoke("attackOn", 3);
            Debug.Log("��� -1");
        }
    }

    //����
    public void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(new Vector2(0.0f, jumpForce));
        jumpCount++;
        
    }

    public void attackOn()
    {
        hasAttacked = false;
    }
    

    
}
