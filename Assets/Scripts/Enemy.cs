using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;

    [SerializeField] float speed;
    public int HP;
    public bool attacked = false;

    CharacterStats AttPow;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    void FixedUpdate()
    {
        Vector2 direction = (targetDestination.position - transform.position).normalized;
        rigid.velocity = (direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == targetGameObject)
        {
            Attack();
        }
        /*
        if (other.gameObject.CompareTag("thorn"))
        {
            Debug.Log("피격");
        }
        */
    }

    private void Attack()
    {
        Debug.Log("플레이어 공격!");
    }

    public void TakeDamage(int damage)
    {
        if (!attacked)
        {
            HP -= damage;
            attacked = true;
            Invoke("attackedOn", 0.5f);
        }
    }

    private void Update()
    {
        if(HP<=0)
        {
            DIE();
        }
    }

    public void attackedOn()
    {
        attacked = false;
    }

    void DIE()
    {
        Destroy(gameObject);
    }

}
