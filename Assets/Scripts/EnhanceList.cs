using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceList : PlayerController
{

    //강화카운트
    public int attackPowerCount = 0;
    public int attackSpeedCount = 0;
    public int attackRangeCount = 0;
    public int avoidanceRateCount = 0;
    public int HPCount = 0;



    void AttackPowerUp()  //공격력증가
    {
        int inc = (attackPower / 100) * 35;  //증가율 계산, 35% = (공격력 / 100) *35;
        attackPower += inc;
        Debug.Log("공격력증가");
        attackPowerCount++;
    }
    void AttackSpeedDown()  //공격속도감소
    {
        attackSpeed -= 0.07;
        Debug.Log("공속감소");
        attackSpeedCount++;
    }
    void AttackRangeUp()  //공격범위증가
    {
        Debug.Log("공범증가");
        attackRangeCount++;
    }
    void AvoidanceRateUp()  //회피율증가
    {
        avoidanceRate += 5;
        Debug.Log("회피율증가");
        avoidanceRateCount++;
    }
    void HPUp()  //목숨증가
    {
        HP += 1;
        Debug.Log("목숨증가");
        HPCount++;
    }

}