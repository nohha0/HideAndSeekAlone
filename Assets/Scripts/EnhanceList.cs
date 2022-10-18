using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhanceList : MonoBehaviour
{
    [SerializeField] Button btn1, btn2, btn3;
    

    public int attackPower = 20;    //���ݷ� 
    public double attackSpeed;      //���ݼӵ�
    public float attackRange;       //���ݹ���
    public int avoidanceRate = 0;   //ȸ����
    public int HP = 4;

    public int attackPowerCount = 0;
    public int attackSpeedCount = 0;
    public int attackRangeCount = 0;
    public int avoidanceRateCount = 0;
    public int hpCount = 0;

    public void StatUp(string spriteName)
    {
        Image spr1 = GameObject.Find("Image1").GetComponent<Image>();
        Image spr2 = GameObject.Find("Image1").GetComponent<Image>();
        Image spr3 = GameObject.Find("Image1").GetComponent<Image>();
        btn1.onClick.AddListener(delegate { StatUp(spr1.sprite.name); });
        btn1.onClick.AddListener(delegate { StatUp(spr2.sprite.name); });
        btn1.onClick.AddListener(delegate { StatUp(spr3.sprite.name); });

        switch (spriteName)
        {
            case "AttackPower":
                //int inc = (attackPower / 100) * 35;  //������ ���, 35% = (���ݷ� / 100) *35;
                //attackPower += inc;
                Debug.Log("���ݷ�����");
                attackPowerCount++;
                break;
            case "AttackRange":
                Debug.Log("��������");
                attackRangeCount++;
                break;
            case "AttckSpeed":
                //attackSpeed -= 0.07; //�����ֱ�(�ð�) ����
                Debug.Log("��������");
                attackSpeedCount++;
                break;
            case "Avoidance":
                //avoidanceRate += 5;
                Debug.Log("ȸ��������");
                avoidanceRateCount++;
                break;
            case "HpUp":
                //HP += 1;
                Debug.Log("�������");
                hpCount++;
                break;
        }
    }
}