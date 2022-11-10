using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Enemy : MonoBehaviour
{
    public float        speed;
    public int          HP;
    public bool         attacked;
    public float        mag;

    protected GameObject targetGameObject;
    protected Rigidbody2D         rigid;
    protected SpriteRenderer spriteRend;
    protected Animator animator;


    void Awake()
    {
        attacked = false;
        targetGameObject = GameObject.FindWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (HP <= 0)
        {
            DIE();
        }

        UpdateTarget();
    }

    void FixedUpdate()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (!attacked)
        {
            spriteRend.color = new Color(0.5f, 0.5f, 0.5f);
            HP -= damage;
            attacked = true;
            Invoke("attackedOn", 1f);
            Invoke("SpriteOn", 0.1f);
        }
    }

    public void attackedOn()
    {
        attacked = false;
    }

    public void SpriteOn()
    {
        spriteRend.color = new Color(1, 1, 1);
    }

    protected void DIE()
    {
        Destroy(gameObject);
    }

    virtual protected void UpdateTarget()     //충돌 범위
    {
        if ((targetGameObject.transform.position - transform.position).magnitude <= mag)
        {
            Vector2 direction = (targetGameObject.transform.position - transform.position).normalized;
            rigid.velocity = new Vector2(direction.x * speed, 0f);
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }

        if (rigid.velocity.x > 0)
            spriteRend.flipX = true;
        else if (rigid.velocity.x < 0)
            spriteRend.flipX = false;

        if (rigid.velocity.magnitude == 0)
            animator.SetBool("walk", false);
        else
            animator.SetBool("walk", true);
    }
}
