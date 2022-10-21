using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;

    [SerializeField] float speed;
    public int HP = 100;

    CharacterStats AttPow;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigid.velocity = direction * speed;
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
            Debug.Log("�ǰ�");
        }
        */
    }

    private void Attack()
    {
        Debug.Log("�÷��̾� ����!");
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
    private void Update()
    {
        if(HP<=0)
        {
            DIE();
        }
    }

    void DIE()
    {
        Destroy(gameObject);
    }

}
