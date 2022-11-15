using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMiddleBoss : Enemy
{

    //Pen ------------------------------------------------------------------------------------
    public GameObject pen;
    public GameObject rotatingPen;
    public int jumpForce;
    public float jumpSpeed;

    Vector3 penPosition;
    Vector3 rotatingPenPosition;
    Vector2 distance;

    float[] penXs = { 1510, 1557, 1604, 1649 };
    float[] penYs = { -524, -494 };

    bool OnPattern = false;
    bool viewing;
    bool firstPatten;
    int rotatepens;
    int pens;

    //Wind ------------------------------------------------------------------------------------
    public GameObject Windywave;

    public float delray;
    float curtime;
    Vector3 setpos;
    int i = 0;

    int SetSkill;

    
    override protected void Start()
    {
        base.Start();
        firstPatten = false;
        viewing = false;
        Patten1();

        curtime = delray;
    }

    override protected void Update()
    {
        base.Update();

        if (firstPatten && viewing && pens == 0) ViewingPen();
        else if (firstPatten && !viewing && rotatepens == 0)
        {
            CreateRotatePen(5);
        }
        else { }


        if (!OnPattern)
        {
            SetSkill = Random.Range(0, 2);
            /*
            switch (SetSkill)
            {
                case 0:
                    Patten1();
                    Debug.Log("000000000");
                    break;

                case 1:
                    Setpos();
                    Debug.Log("111111111");
                    break;
            }
            */

            Invoke("Patten1", 3);
        }
    }


    //Pen ------------------------------------------------------------------------------------

    void Patten1()
    {
        Invoke("Jump1", 3);
        viewing = true;
        OnPattern = true;
    }


    void Jump1()
    {
        firstPatten = true;
        distance = targetGameObject.transform.position - transform.position;
        rigid.AddForce(new Vector2(distance.x * jumpSpeed, jumpForce));
        //Invoke("Jump", 3);
    }

    void Jump2()
    {

    }

    void ViewingPen()
    {
        pens++;
        penPosition = new Vector3(transform.position.x, transform.position.y + 30f, transform.position.z);
        Instantiate(pen, penPosition, transform.rotation);

        Invoke("OffViewing", 1);
    }

    void CreateRotatePen(int count)
    {
        if (rotatepens >= count)
        {
            rotatepens = 0;
            OnPattern = false;
            firstPatten = false;
            return;
        }

        rotatepens++;
        //float penX = Random.RandomRange(1509f, 1652f);
        //float penY = Random.RandomRange(-524f, -483f);
        int Xindex = Random.Range(0, 4); //0,1,2,3
        int Yindex = Random.Range(0, 2); //0,1,2

        rotatingPenPosition = new Vector3(penXs[Xindex], penYs[Yindex], transform.position.z);
        Instantiate(rotatingPen, rotatingPenPosition, transform.rotation);

        Invoke("CreateRotatePen", 2);

    }

    void OffViewing()
    {
        viewing = false;
    }

    //Wind ------------------------------------------------------------------------------------


    void Setpos()
    {
        OnPattern = true;

        if (i >= 7)
        {
            i = 0;
            OnPattern = false;
            return;
        }

        if (i < 7)
        {
            if (!spriteRend.flipX)  //캐릭터가 오른쪽에 있을경우  
            {
                if (curtime <= 0 && i < 3)
                {
                    Vector3 setpos = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
                    Instantiate(Windywave, setpos, transform.rotation);
                    curtime = delray;
                    i++;

                }
                else if (i == 3 && curtime <= 0)
                {
                    curtime = 0.6f;
                    i++;
                }
                else if (i > 3 && curtime <= 0)
                {
                    setpos = new Vector3(transform.position.x + 10, transform.position.y + 45, transform.position.z);
                    Instantiate(Windywave, setpos, transform.rotation);
                    curtime = delray;
                    i++;
                }
                
            }
            curtime -= Time.deltaTime;
        }

        Setpos();
    }

}
