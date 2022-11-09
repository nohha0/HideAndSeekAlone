using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLight : FlyingMonster
{
    public GameObject Lightwave;
    float cooltime = 5;
    float curtime;
    void Start()
    {
        curtime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        if(curtime <= 0&&SetOn)
        {
            
            Instantiate(Lightwave, pos.position, transform.rotation);
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;

    }
}
