using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceList : PlayerController
{

    //��ȭī��Ʈ
    public int attackPowerCount = 0;
    public int attackSpeedCount = 0;
    public int attackRangeCount = 0;
    public int avoidanceRateCount = 0;
    public int HPCount = 0;



    void AttackPowerUp()  //���ݷ�����
    {
        int inc = (attackPower / 100) * 35;  //������ ���, 35% = (���ݷ� / 100) *35;
        attackPower += inc;
        Debug.Log("���ݷ�����");
        attackPowerCount++;
    }
    void AttackSpeedDown()  //���ݼӵ�����
    {
        attackSpeed -= 0.07;
        Debug.Log("���Ӱ���");
        attackSpeedCount++;
    }
    void AttackRangeUp()  //���ݹ�������
    {
        Debug.Log("��������");
        attackRangeCount++;
    }
    void AvoidanceRateUp()  //ȸ��������
    {
        avoidanceRate += 5;
        Debug.Log("ȸ��������");
        avoidanceRateCount++;
    }
    void HPUp()  //�������
    {
        HP += 1;
        Debug.Log("�������");
        HPCount++;
    }

}