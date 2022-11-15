using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdMiddleBoss : Enemy
{
    //몬스터 소환프리팹 

    [SerializeField] GameObject Nomal_1;
    [SerializeField] GameObject Nomal_2;
    [SerializeField] GameObject Fly_1;
    [SerializeField] GameObject Fly_2;

    //소환위치를 정하기 위한 pos
    [SerializeField] Transform pos;



    int CurrentPos;         //중보스에 현위치를 알려줌

    //Skill : 0 = 칼 던지기스킬, 1 = 돌진, 2 = 소환, 3 = 텔포  
    int BeforeSkill;        //중복이 되면 안되는 스킬이 있기 때문에 그걸 판단하는 정수
    int SetSkill;           //시전할 스킬 랜덤값으로 고름
    Transform SummonPos;    //몬스터 소환시 기점으로 하는 포스
    SpriteRenderer rend;    //중보스 

    //돌진 Speed



    override protected void Start()
    {
        base.Start();

        Teleport(); //중앙에있던 보스를 텔포로 위치 잡기
        SetSkill = Random.Range(0, 3);   //처음 할 스킬 고르기

    }

    override protected void Update()
    {
        base.Update();



        if (SetSkill == 0)
        {
            KnifeSkill();
        }


    }

    //스킬
    //--------------------------------------------------------------------
    //몬스터 소환스킬
    void SummonSkill()
    {
        int SetMoster;
        if (CurrentPos == 2)   //중보스 위치가 중앙이라면
        {
            //기본3, 비행 3 소환
        }
        else
        {
            SetMoster = Random.Range(0, 1);
            if (SetMoster == 0)
            {
                //기본 4
            }
            if (SetMoster == 1)
            {
                //비행 4
            }
        }
        BeforeSkill = 2; //소환수행완료
        SetSkill = Random.Range(0, 3);  //새로운 스킬

    }

    //보스 돌진 스킬
    void ForwardSKill()
    {
        float ForWardTime = 0;  //돌진 진행하는 시간

        if (ForWardTime < 1f)
        {
            if(rend.flipX) //오른쪽 돌진
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            if(!rend.flipX) //왼쪽 돌진
            {
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
            }


        }
        ForWardTime += Time.deltaTime;  //시간증가


        Teleport();   //돌진하면 언제나 텔포로 위치 재정립
        BeforeSkill = 1; //돌진수행완료
        SetSkill = Random.Range(0, 3);
    }

    //식칼 던지는 스킬 : 이 함수에서는 프리팹을 소환만 한다.
    void KnifeSkill()
    {
        // 랜덤함수  | b = 2
        // 소환 대각 위에서 대각 아래로

        //대각 아래에서 대각 위로

        //정면으로

    }
    void Teleport()
    {
        if (BeforeSkill != 3)    //직전 사용스킬이 텔포가 아닐경우 수행
        {
            CurrentPos = Random.Range(0, 2);   //텔포 위치 정하는 함수
            if (CurrentPos == 2)   //중앙에 텔포가 된다면
            {
                //중앙으로 이동하는 메소드 작성
                SummonSkill();

                //다시 중앙외에 텔포
                CurrentPos = Random.Range(0, 1);
                if (CurrentPos == 0)
                {
                    //왼쪽텔포
                }
                else
                {
                    //오른쪽텔포
                }
            }
            else if (CurrentPos == 0)
            {
                //왼쪽텔포
            }
            else
            {
                //오른쪽텔포
            }

        }
        BeforeSkill = 3; //텔포수행완료
        SetSkill = Random.Range(0, 3);
    }
    //-----------------------------------------------------------------------


    //보조함수


    //소환 위치 정하는 함수
    void SummonSetPos()
    {
        if (CurrentPos == 3)  //중앙에 위치
        {
            //기본 3, 비행 3 고정 포지션  포지션 6개 설정
        }
        else
        {
            int SetPos = Random.Range(0, 1);
            if (SetPos == 0)
            {
                //보스를 기점한 포스값
            }
            if (SetPos == 0)
            {
                //플레이어를 기점한 포스값
            }
        }
    }




    //보스 텔포 위치 |  b = 2
    // 0 = 왼쪽, 1 = 오른쪽, 2 = 중앙

    //소환되는 에너미 종류 |   b = 1 
    //0 = 기본 4, 1 = 비행 4
    //if 보스가 중앙에 있을경우 기본 3, 비행 3

    //if 보스가 왼쪽, 혹은 오른쪽에 있을경우  | b = 3
    //0 = 칼 던지기스킬, 1 = 돌진, 2 = 텔포,  3 = 소환
}