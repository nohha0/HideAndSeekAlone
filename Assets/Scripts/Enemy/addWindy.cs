using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWindy : MonoBehaviour
{
    GameObject secondboss;  //���� ���� Ȯ��
    Rigidbody2D riged;
    SpriteRenderer rend;    //�ٶ� �¿����
    private data script;

    bool Xcon;              //x��ǥ ��Ʈ��
    bool SetShoot = true;   //���� ����
    float backmove = 0;
    public float speed;
    public float fastspeed;


    void Start()
    {
        secondboss = GameObject.Find("SecondBoss");
        rend = GetComponent<SpriteRenderer>();
        riged = GetComponent<Rigidbody2D>();
        Invoke("OnDestroy", 10);
        script = GameObject.Find("Main Camera").GetComponent<data>();            //��ũ��Ʈ ����

        fastspeed = speed = 160;

        // ī��Ʈ �ϱ� ���� Filp ����
        if (!secondboss.GetComponent<SpriteRenderer>().flipX)
        {
            Debug.Log("++1");
            script.Lcount++;
        }
        if (secondboss.GetComponent<SpriteRenderer>().flipX)
        {
            script.Rcount++;
        }
    }


    void Update()
    {
        Shoot();

        if (script.Lcount == 6)
        {
            Invoke("Backright", 1.2f);
            Invoke("set", 7);
        }
        if (script.Rcount == 6)
        {
            Invoke("Backleft", 1.2f);
            Invoke("set", 7);
        }

    }

    void XFcon()
    {
        if (SetShoot && secondboss.GetComponent<SpriteRenderer>().flipX)
        {
            Xcon = true;
            SetShoot = false;
        }
        else if (SetShoot && !secondboss.GetComponent<SpriteRenderer>().flipX)
        {
            Xcon = false;
            SetShoot = false;
        }

    }
    void Shoot()
    {
        backmove += Time.deltaTime;
        XFcon();
        if (Xcon)
        {
            if (backmove <= 1.5f)
            {
                rend.flipX = true;
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            else
            {
                rend.flipX = false;
                riged.velocity = Vector2.zero;   //���� ����
            }

        }
        else if (!Xcon)
        {
            if (backmove <= 1.5f)
            {
                rend.flipX = false;
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
            }
            else
            {
                rend.flipX = true;
                riged.velocity = Vector2.zero;   //���� ����
            }
        }
    }

    public void Backright()     //���������� ���ư�
    {
        transform.Translate(transform.right * fastspeed * Time.deltaTime);
    }
    public void Backleft()     //�������� ���ư�
    {
        transform.Translate(transform.right * -1 * fastspeed * Time.deltaTime);
    }

    private void set()
    {
        script.Rcount = 0;
        script.Lcount = 0;
    }


    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}
