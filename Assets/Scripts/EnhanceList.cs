using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceList :PlayerController
{

    //강화카운트
    public int AttackCount = 0;
    public int AttackSpeedCount = 0;
    public int AttackScailCount = 0;
    public int AvoidanceCount = 0;
    public int HPCount = 0;



    void AttackUp()  //공격력증가
    {
        int inc = (Attack / 100) * 35;  //증가율 계산, 35% = (공격력 / 100) *35;
        Attack += inc;
        Debug.Log("공격력증가");
        AttackCount++;
    }
    void AttackSpeedDown()  //공격속도감소
    {
        AttackSpeed -= 0.07;
        Debug.Log("공속감소");
        AttackSpeedCount++;
    }
    void AttackScailUp()  //공격범위증가
    {
        Debug.Log("공범증가");
        AttackScailCount++;
    }
    void AvoidanceUp()  //회피율증가
    {
        Avoidance += 5;
        Debug.Log("회피율증가");
        AvoidanceCount++;
    }
    void HPUp()  //목숨증가
    {
        HP += 1;
        Debug.Log("목숨증가");
        HPCount++;
    }

}