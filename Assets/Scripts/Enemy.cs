using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject targetGameObject;

    [SerializeField] float speed;
    public int HP;
    public bool attacked = false;

    CharacterStats AttPow;

    Rigidbody2D rigid;
    SpriteRenderer spriteRend;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        targetGameObject = GameObject.Find("Player").gameObject;
    }

    void FixedUpdate()
    {
        Vector2 direction = (targetGameObject.transform.position - transform.position).normalized;
        rigid.velocity = new Vector2(direction.x * speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("플레이어 공격!");
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

    private void Update()
    {
        if(HP<=0)
        {
            DIE();
        }

        if (rigid.velocity.x >= 0) 
            spriteRend.flipX = true;
        else 
            spriteRend.flipX = false;
    }

    public void attackedOn()
    {
        attacked = false;
    }

    public void SpriteOn()
    {
        spriteRend.color = new Color(1, 1, 1);
    }

    void DIE()
    {
        Destroy(gameObject);
    }

}
