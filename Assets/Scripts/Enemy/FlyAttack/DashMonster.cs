using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMonster : FlyingMonster
{
    Vector2 forward;
    bool setLook = true;
    float cooltime = 4;
    float curtime;
    float Dashspeed = 80;

    void Start()
    {
        curtime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();

        if(curtime <=0)
        {
            if(setLook)
            {
                forward = (targetGameObject.transform.position - transform.position).normalized; //���� ����
                setLook = false;
            }
            transform.Translate(forward * Dashspeed * Time.deltaTime);
            Invoke("SETCUR", 1.5f);

        }
        curtime -= Time.deltaTime;
    }
    void SETCUR()
    {
        curtime = cooltime;
        setLook = true;
    }


}
