using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    CharacterStats stats;
    Animator animator;

    public float walkSpeed;
    public float jumpForce;
    public float dashSpeed;
    public float dashUpForce;
    int direction;

    public int jumpCount = 0;
    public bool isLongJump = false;
    public bool hasAttacked = false;   //�ǰ� �ߺ� ����
    public bool dashOn = false;

    //���� ��ũ��Ʈ
    private Attack script;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stats = GetComponent<CharacterStats>();
        animator = GetComponent<Animator>();

        script = GameObject.Find("Player").GetComponent<Attack>();  //���� ��ũ��Ʈ ����
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

        if (Input.GetKey(KeyCode.LeftArrow)&&script.AttackOn)
        {
            direction = 1;
            spriteRenderer.flipX = false;
            Vector2 vec = transform.position;
            vec += new Vector2(-walkSpeed * Time.deltaTime, 0.0f);
            transform.position = vec;
            animator.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.RightArrow) && script.AttackOn)
        {
            direction = 2;
            spriteRenderer.flipX = true;
            Vector2 vec = transform.position;
            vec += new Vector2(walkSpeed * Time.deltaTime, 0.0f);
            transform.position = vec;
            animator.SetBool("run", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashOn)
        {
            dashOn = true;
            Dash();
            Invoke("DashOn", 1);
        }
    }

    //Rigidbody(��������)�� �̿��� ���� FixedUpdate�� �ۼ�
    private void FixedUpdate()
    {
        if (isLongJump) //rigid.velocity.y ���� ��� ������
            rigid.gravityScale = 15.0f;
        else
            rigid.gravityScale = 20.0f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
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

    public void Dash()
    {
        Debug.Log("�뽬");

        rigid.velocity = Vector2.zero;
        
        if (direction == 1)
        {
            rigid.AddForce(new Vector2(-dashSpeed, dashUpForce));
        }

        if (direction == 2)
        {
            rigid.AddForce(new Vector2(dashSpeed, dashUpForce));
        }
    }

    public void attackOn()
    {
        hasAttacked = false;
    }

    public void DashOn()
    {
        dashOn = false;
    }    
}
