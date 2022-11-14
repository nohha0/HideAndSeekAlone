using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FirstMiddleBoss : Enemy
{
    public GameObject scissors;
    public GameObject branch;

    Vector3 scissorsPosition;
    int scissorsCount;
    int branchCount;

    override protected void Start()
    {
        base.Start();
        scissorsCount = 0;
        branchCount = 0;
        ThrowScissors(5);
    }

    override protected void Update()
    {
        base.Update();
    }

    void ThrowScissors(int count)
    {
        if (scissorsCount >= count)
        {
            scissorsCount = 0;
            return;
        }
        scissorsCount++;
        scissorsPosition = new Vector3(transform.position.x, transform.position.y + 30f, transform.position.z);
        Instantiate(scissors, scissorsPosition, transform.rotation);

        //Invoke("ThrowScissors", 2);
    }

}
