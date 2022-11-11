using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWindy : MonoBehaviour
{
    GameObject secondboss;  //���� ���� Ȯ��
    public float speed;
    float fastspeed;
    SpriteRenderer rend;    //�ٶ� �¿����


    bool Xcon;              //x��ǥ ��Ʈ��
    bool SetShoot = true;   //���� ����
    float backmove = 0;
    void Start()
    {
        secondboss = GameObject.Find("SecondBoss");
        rend = GetComponent<SpriteRenderer>();
        Invoke("OnDestroy", 10);
        fastspeed = speed + 200;
    }


    void Update()
    {
        backmove += Time.deltaTime;
        XFcon();
        if (Xcon)
        {
            if(backmove <=3f)
            {
                rend.flipX = true;
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            else
            {
                rend.flipX = false;
                transform.Translate(transform.right * -1 * fastspeed * Time.deltaTime);
            }

        }
        else if (!Xcon)
        {
            if (backmove <= 3f)
            {
                rend.flipX = false;
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
            }
            else
            {
                rend.flipX = true;
                transform.Translate(transform.right * fastspeed * Time.deltaTime);
            }
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
    void Left()
    {
        transform.Translate(transform.right * -1 * fastspeed * Time.deltaTime);
    }
    void Right()
    {
        transform.Translate(transform.right * fastspeed * Time.deltaTime);
    }


    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}
