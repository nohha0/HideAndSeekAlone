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
    int i = 0;
    private data script;  //스크립트 접근


    float SetSkill;

    bool SetWindy = false;    //함수 소환

    
    override protected void Start()
    {
        base.Start();
        firstPatten = false;
        viewing = false;


        script = GameObject.Find("Main Camera").GetComponent<data>();
        curtime = delray;
    }

    override protected void Update()
    {
        base.Update();
        if (firstPatten && viewing && pens == 0) ViewingPen();
        else if (firstPatten && !viewing && rotatepens == 0)
        {
            CreateRotatePen();
        }
        else { }


        if (!OnPattern)
        {
            OnPattern = true;
            SetSkill = Random.RandomRange(0, 101);

            if (SetSkill > 90)
            {
                Invoke("Patten1", 2);
                //Patten1();
                Debug.Log("000000000");
            }
            else
            {
                i = 0;
                curtime = 0;
                Invoke("Setpos", 2);
                Debug.Log("111111111");
            }
        }
    }


    //Pen ------------------------------------------------------------------------------------

    void Patten1()
    {
        Invoke("Jump1", 3);
        viewing = true;
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

    void CreateRotatePen()
    {
        if (rotatepens >= 4)
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
        pens = 0;
    }

    //Wind ------------------------------------------------------------------------------------


    void Setpos()
    {

        if (i >= 3)
        {
            SetWindy = false;
            OnPattern = false;
            
            return;  //리턴될떄 게임에 전부 전달
        }
        SetWindy = true;

            Setpos();
    }

    void InstantDOWN()
    {
        Vector3 setpos1 = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        Instantiate(Windywave, setpos1, transform.rotation);
        script.Lcount++;

    }
    void InstantUP()
    {
        Vector3 setpos2 = new Vector3(transform.position.x + 10, transform.position.y + 45, transform.position.z);
        Instantiate(Windywave, setpos2, transform.rotation);
        script.Lcount++;
    }

    private void FixedUpdate()
    {

        if(SetWindy)
        {
            if (!spriteRend.flipX)  //캐릭터가 오른쪽에 있을경우  
            {
                if (curtime <= 0 && i < 3)
                {
                    InstantDOWN();
                    Invoke("InstantUP", 0.2f);
                    curtime = delray;
                    i++;
                }
                curtime -= Time.deltaTime;
            }
        }
    }
}



