using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlyingMonster : Enemy
{
    public Transform targetDestination;
    public Transform pos;     //�ش� ���ʹ��� ��ġ��ǥ ���� �ڽ� Ŭ���������� ���

    override protected void Start()
    {
        base.Start();
        targetGameObject = targetDestination.gameObject;
        //InvokeRepeating("UpdateTarget", 0f, 0.25f); //0�� �Ŀ� 0.25�ʸ��� �Լ� ����
    }

    override protected void UpdateTarget()
    {
        Vector3 PlayerPos = targetDestination.position;
        float setflip = pos.position.x - PlayerPos.x;  // �¿� ����

        if ((targetGameObject.transform.position - transform.position).magnitude <= mag)
        {
            Debug.Log("�����ȿ�����");

            if (setflip > 0)    //�÷��̾ ���ʿ� ��ġ�� ���
            {
                Debug.Log("����^^");
                spriteRend.flipX = false;
                Vector3 enemypos = new Vector3(PlayerPos.x + 35f, PlayerPos.y + 25, this.transform.position.z); //�Ƿ��� ���� ��ġ
                Vector2 direction = (enemypos - transform.position).normalized;
                rigid.velocity = direction * speed;
            }
            else if (setflip < 0)  //�÷��̾ �����ʿ� ��ġ�� ���
            {
                Debug.Log("������^^");
                spriteRend.flipX = true;
                Vector3 enemypos = new Vector3(PlayerPos.x - 35f, PlayerPos.y + 25, this.transform.position.z); //�Ƿ��� ���� ��ġ
                Vector2 direction = (enemypos - transform.position).normalized;
                rigid.velocity = direction * speed;
            }
        }
    }

   
}