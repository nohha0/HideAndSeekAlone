using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceList :PlayerController
{

    //��ȭī��Ʈ
    public int AttackCount = 0;
    public int AttackSpeedCount = 0;
    public int AttackScailCount = 0;
    public int AvoidanceCount = 0;
    public int HPCount = 0;



    void AttackUp()  //���ݷ�����
    {
        int inc = (Attack / 100) * 35;  //������ ���, 35% = (���ݷ� / 100) *35;
        Attack += inc;
        Debug.Log("���ݷ�����");
        AttackCount++;
    }
    void AttackSpeedDown()  //���ݼӵ�����
    {
        AttackSpeed -= 0.07;
        Debug.Log("���Ӱ���");
        AttackSpeedCount++;
    }
    void AttackScailUp()  //���ݹ�������
    {
        Debug.Log("��������");
        AttackScailCount++;
    }
    void AvoidanceUp()  //ȸ��������
    {
        Avoidance += 5;
        Debug.Log("ȸ��������");
        AvoidanceCount++;
    }
    void HPUp()  //�������
    {
        HP += 1;
        Debug.Log("�������");
        HPCount++;
    }

}