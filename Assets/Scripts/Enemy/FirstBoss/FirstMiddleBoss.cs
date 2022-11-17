using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FirstMiddleBoss : Enemy
{
    public GameObject scissors;
    public GameObject branch;

    Vector3 scissorsPosition;
<<<<<<< Updated upstream
    int scissorsCount;
    int branchCount;

    override protected void Start()
    {
        base.Start();
        scissorsCount = 0;
        branchCount = 0;
        ThrowScissors(5);
=======
    Vector3 branchPosition;

    float[] branchXs = { 1517, 1580, 1644 };
    bool onBranch;
    bool onScissors;
    float timeUntilChangeState;
    bool callBranch;
    bool callScissors;

    override protected void Start()
    {
        base.Start();
        onScissors = false;
        onBranch = false;
        callBranch = false;
        callScissors = false;
        timeUntilChangeState = 0f;
>>>>>>> Stashed changes
    }

    override protected void Update()
    {
        base.Update();
        ChangeState();
        if (onBranch && !callBranch) CreateBranch();
        if (onScissors && !callScissors) ThrowScissors();
    }

<<<<<<< Updated upstream
    void ThrowScissors(int count)
    {
        if (scissorsCount >= count)
        {
            scissorsCount = 0;
            return;
        }
        scissorsCount++;
=======
    void CreateBranch()
    {
        callBranch = true;
        Debug.Log("CreateBranch");
        int randPos = Random.Range(0, 3);
        branchPosition = new Vector3(branchXs[randPos], transform.position.y - 50f, transform.position.z);
        Instantiate(branch, branchPosition, transform.rotation);
        Invoke("CreateBranch", 2);
    }

    void ThrowScissors()
    {
        callScissors = true;
        Debug.Log("ThrowScissors");
>>>>>>> Stashed changes
        scissorsPosition = new Vector3(transform.position.x, transform.position.y + 30f, transform.position.z);
        Instantiate(scissors, scissorsPosition, transform.rotation);
        Invoke("ThrowScissors", 2);
    }



    void ChangeState()
    {
        timeUntilChangeState -= Time.deltaTime;

        if (timeUntilChangeState <= 0)
        {
            timeUntilChangeState = 10;
            callBranch = false;
            callScissors = false;

            int rand = Random.Range(0, 2);
            Debug.Log(rand);

            if (rand == 0)
            {
                onBranch = true;
                onScissors = false;
            }
            else
            {
                onBranch = false;
                onScissors = true;
            }
        }
    }
}
