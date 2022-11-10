using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardFireWave : MonoBehaviour
{
    GameObject player;
    SpriteRenderer rend;
    public float speed;
    bool Xcon;
    float settime = 2;

    void Start()
    {
        player = GameObject.Find("Player");
        rend = GetComponent<SpriteRenderer>();
        Invoke("OnDestroy", 2);
    }

    void Update()
    {
        XFcon();
        if (Xcon)
        {
            rend.flipX = true;
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (!Xcon)
        {
            rend.flipX = false;
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }



    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    void XFcon()
    {
        if (settime == 2f && player.GetComponent<SpriteRenderer>().flipX)
        {
            Xcon = true;
            settime = 0f;
        }
        else if (settime == 2f && !player.GetComponent<SpriteRenderer>().flipX)
        {
            Xcon = false;
            settime = 0f;
        }
        else
        {
            settime += Time.deltaTime;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(200);
        }
    }


}
