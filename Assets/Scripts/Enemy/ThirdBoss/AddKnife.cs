using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKnife : MonoBehaviour
{
    private ThirdMiddleBoss script;
    SpriteRenderer rend;  //������ ��������Ʈ����
    SpriteRenderer Rend;
    public float speed = 130;
    void Start()
    {
        script = GameObject.Find("Player").GetComponent<ThirdMiddleBoss>();
        rend = GameObject.Find("ThirdBoss").GetComponent<SpriteRenderer>();
        Rend = GetComponent<SpriteRenderer>();
        Invoke("OnDestroy", 5);

        /*
         * if (!rend.flipX) //���� ���� ��
        {
            if (script.Knife_Pattern == 1)//����
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (script.Knife_Pattern == 2)//����
            {
                transform.rotation = Quaternion.Euler(0, 0, 70);
            }
            if (script.Knife_Pattern == 3)//�Ʒ���
            {
                transform.rotation = Quaternion.Euler(0, 0, 115);
            }
        }
        if(rend.flipX) //������ ������
        {
            Rend.flipX = true;
            if (script.Knife_Pattern == 1)//����
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (script.Knife_Pattern == 2)//����
            {
                transform.rotation = Quaternion.Euler(0, 0, 120);
            }
            if (script.Knife_Pattern == 3)//�Ʒ���
            {
                transform.rotation = Quaternion.Euler(0, 0, 70);
            }
        }
         * */

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.forward * speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
