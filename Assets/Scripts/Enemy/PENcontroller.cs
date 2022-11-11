using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PENcontroller : Enemy
{
    public GameObject pen;
    public GameObject rotatingPen;

    Vector3 penPosition;
    Vector3 rotatingPenPosition;

    float[] penXs = { 1510, 1557, 1604, 1649 };
    float[] penYs = { -524, -494 };

    bool viewing;
    bool firstPatten;
    int rotatepens;
    int pens;

    override protected void Start()
    {
        base.Start();
        firstPatten = false;
        viewing = false;
        Patten1();
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
    }

    //패턴 시작할 때 이 함수만 실행시키면 됨
    void Patten1()
    {
        firstPatten = true;
        viewing = true;
    }

    void ViewingPen()
    {
        pens++;
        penPosition = new Vector3(transform.position.x, transform.position.y + 30f, transform.position.z);
        Instantiate(pen, penPosition, transform.rotation);

        Invoke("OffViewing", 2);
    }

    void CreateRotatePen()
    {
        if (rotatepens >= 50) return;

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
}
