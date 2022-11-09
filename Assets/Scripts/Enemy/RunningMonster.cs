using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMonster : Enemy
{
    override protected void UpdateTarget()
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
}
