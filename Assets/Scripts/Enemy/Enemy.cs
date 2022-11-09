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


    virtual protected void Start()
    {
        attacked = false;
        targetGameObject = GameObject.FindWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    virtual protected void Update()
    {
        if (HP <= 0) DIE();
        UpdateTarget();
    }

    virtual protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Attack();
        }
    }

    public void Attack()
    {
        Debug.Log("�÷��̾� ����!");
    }

    virtual protected void UpdateTarget()
    {
        //������ ~Monster �ڽ� Ŭ�������� ����
    }

    virtual public void TakeDamage(int damage)
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

    public void DIE()
    {
        Destroy(gameObject);
    }

    
}
