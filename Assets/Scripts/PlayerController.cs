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
    public bool hasAttacked = false;
    public int HP = 4;
    public int Attack = 20;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            isLongJump = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            Jump();
        }

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

    private void FixedUpdate()
    {
        if (isLongJump && rigid.velocity.y>0)   
        {
            rigid.gravityScale = 2.0f;
        }
        else
        {
            rigid.gravityScale = 4.0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Ãæµ¹");
            this.jumpCount = 0;
        }

        if (other.gameObject.CompareTag("Enemy")&&!hasAttacked)
        {
            this.HP--;
            hasAttacked = true;
            Invoke("attackOn", 3);
            Debug.Log("¸ñ¼û -1");
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
