using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMonster : Enemy
{
    [SerializeField] int    number;
    public int              jumpForce;
    Vector2                 distance;
    bool                    isGround;
    bool                    onWalk;

    override protected void Start()
    {
        base.Start();
        isGround = true;
        onWalk = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            rigid.velocity = Vector2.zero;
            isGround = true;
        }
    }

    override protected void UpdateTarget()
    {
        distance = targetGameObject.transform.position - transform.position;

        if (distance.magnitude <= mag && isGround)
        {
            number = Random.Range(1, 11);

            if (number > 1) //걸어옴
            {
                //onWalk = true;
                //Invoke("OffWalk", 2);
                rigid.velocity = new Vector2(distance.normalized.x * speed, 0f);
            }
            else //점프함
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(distance.normalized.x * speed * 5, jumpForce));
                isGround = false;
            }
        }
        else if(isGround)
        {
            rigid.velocity = Vector2.zero;
        }
        else { }


        if (rigid.velocity.x > 0)
            spriteRend.flipX = true;
        else if (rigid.velocity.x < 0)
            spriteRend.flipX = false;
        else { }

        if (rigid.velocity.magnitude == 0)
            animator.SetBool("walk", false);
        else
            animator.SetBool("walk", true);
    }

    override public void TakeDamage(int damage)
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

    public void OffWalk()
    {
        onWalk = false;
    }
}
